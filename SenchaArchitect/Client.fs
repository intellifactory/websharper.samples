namespace Website

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.JQuery
open IntelliFactory.WebSharper.ExtJS

type App = SenchaArchitect.App<"app.js", Inherit = true>

[<JavaScript>]
module Client =    
    type LoadMask(comp : Ext.Component) =
        do comp.SetLoading(true) |> ignore
        
        interface System.IDisposable with
            member this.Dispose() = comp.SetLoading(false) |> ignore
    
    [<Inline "$x || $y">]
    let (||?) (x: 'a) (y: 'a) = X<'a> 

    let MainView() = 
        let view = App.View.MainView.MainView
        
        let grid = view.grid
        let form = view.form
        let gridToolbar = grid.toolbar
        let formToolbar = form.toolbar

        let isLoadingData = ref false
        let loadData() =
            if not !isLoadingData then
                async {
                    use _ = new LoadMask(grid)
                    let! data = Remoting.GetAttending()
                    data |> Array.map (fun p -> 
                        box <| App.RawModel.Person(Name = p.Name, Age = p.Age)
                    )
                    |> App.Store.Persons.LoadData
                }
                |> Async.Start
        
        loadData()

        grid.refreshTool.OnClick(loadData)
                 
        grid.uploadTool.OnClick(fun () ->
            let data =
                (App.Store.Persons.Snapshot ||? As App.Store.Persons.Data).GetRange()
                |> As<App.Model.Person[]> |> Array.map (fun p ->
                    {
                        Name = p.Name
                        Age  = p.Age
                    }  
                )
            JavaScript.Log data
            async {
                let! res = Remoting.Save data
                Ext.MessageBox.Alert("Success", string res + " records saved. (not really)")
            }
            |> Async.Start
        )

        let showAdults = ref false
        let searchString = ref None

        let setFilter() =
            let store = App.Store.Persons
            store.ClearFilter()
            store.AddFilter [|
                if !showAdults then
                    yield box (fun (m: App.Model.Person) -> m.Age >= 18)
                match !searchString with
                | Some text ->
                    yield box (fun (m: App.Model.Person) -> m.Name.Contains text)
                | _ -> () 
            |]

        gridToolbar.showAdultsButton.OnToggle(fun (_, state) ->
            showAdults := state
            setFilter()
        )

        let prompt title msg (onOk: string -> unit) =
            Ext.MessageBox.Prompt(title, msg,
                As (function "ok", text -> onOk text | _ -> ())
            )    

        gridToolbar.searchButton.OnClick(fun () ->
            prompt "Search" "Part of name:" (fun text ->
                searchString := Some text
                gridToolbar.searchLabel.SetText("Current search: '" + text + "'")
                setFilter()
            )
        )  

        gridToolbar.searchButton.menu.clearSearchItem.OnClick(fun () ->
            searchString := None
            gridToolbar.searchLabel.SetText("")
            setFilter()
        )

        grid.OnSelect(fun (_, m: Ext.data.Model) ->
            form.LoadRecord(m) |> ignore
        )

        grid.OnSelectionchange(fun (_, sel) ->
            if Array.isEmpty sel then
                formToolbar.saveButton.Disable()
                formToolbar.deleteButton.Disable()
            else
                formToolbar.saveButton.Enable()
                formToolbar.deleteButton.Enable()
        )

        formToolbar.newButton.OnClick(fun () -> 
            let added = App.RawModel.Person(Name = "", Age = 0).ToModel()
            App.Store.Persons.Add(added) |> ignore
            grid.GetSelectionModel().Select([| added.self |])
        )

        formToolbar.deleteButton.OnClick(fun () ->
            form.GetRecord() |> App.Store.Persons.Remove
            form.SetValues <| App.View.MainView.Form.FieldValues(Name = "", Age = 0)
        )

        formToolbar.saveButton.OnClick(fun () ->
            form.UpdateRecord() |> ignore
            form.GetRecord().Commit()
        )       
       
    [<Require(typeof<Resources.ExtAll>)>]
    [<Require(typeof<Resources.ExtThemeNeptune>)>]
    [<Require(typeof<Resources.ExtAllNeptuneCss>)>]
    let Main () =
        Ext.OnReady(As MainView, null, null)
        Div []