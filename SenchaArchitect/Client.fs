namespace Samples

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html5
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.JQuery
open IntelliFactory.WebSharper.ExtJS

type App = SenchaArchitect.App<"app.js">

[<JavaScript>]
module SenchaArchitectSample =
    [<Require(typeof<Resources.ExtAll>)>]
    [<Require(typeof<Resources.ExtThemeNeptune>)>]
    [<Require(typeof<Resources.ExtAllNeptuneCss>)>]
    let initMainView() =        
        let view = App.View.MainView.MainView

        let grid = view.grid
        let form = view.form
        let toolbar = form.toolbar

        grid.OnSelect(fun (_, m: Ext.data.Model) ->
            let m = App.Model.Person(m)
            form.SetValues <| App.View.MainView.Form.FieldValues(name = m.Name, age = m.Age)
        )

        grid.OnSelectionchange(fun (_, sel) ->
            if Array.isEmpty sel then
                toolbar.saveButton.Disable()
                toolbar.deleteButton.Disable()
            else
                toolbar.saveButton.Enable()
                toolbar.deleteButton.Enable()
        )

        toolbar.addButton.SetHandler <| fun () -> 
            let sel = grid.GetSelectionModel().GetSelection()
            let added =
                if Array.isEmpty sel then
                    let v = form.GetValues()    
                    App.RawModel.Person(Name = v.name, Age = v.age).ToModel()
                else App.RawModel.Person(Name = "", Age = 0).ToModel()
            App.Store.Persons.Add(added) |> ignore
            grid.GetSelectionModel().Select([| added.self |])

        toolbar.deleteButton.SetHandler <| fun () ->
            grid.GetSelectionModel().GetSelection() |> App.Store.Persons.Remove
            form.SetValues <| App.View.MainView.Form.FieldValues(name = "", age = 0)

        toolbar.saveButton.SetHandler <| fun () ->
            let sel = grid.GetSelectionModel().GetSelection()
            if not <| Array.isEmpty sel then 
                let v = form.GetValues()
                let m = App.Model.Person(sel.[0])
                m.Age <- v.age
                m.Name <- v.name
                m.self.Commit()

type SenchaArchitectViewer() =
    inherit Web.Control()

    [<JavaScript>]
    override this.Body =
        JQuery.Of("head")
            .Append("""<script type="text/javascript" src="app.js"></script>""")
            |> ignore

        upcast Div [] |>! OnAfterRender (fun el ->
            Ext.OnReady(SenchaArchitectSample.initMainView, null, null)
        )
