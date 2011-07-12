namespace StickyNotes

open System
open System.Web

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.JQuery

[<assembly: System.Web.UI.WebResource("StickyNotes.css", "text/css", PerformSubstitution = true)>]
[<assembly: System.Web.UI.WebResource("remove.png", "image/png")>]
[<assembly: System.Web.UI.WebResource("remove_active.png", "image/png")>]
do()

module Extensions = 
    type IntelliFactory.WebSharper.Html.Element with
        [<JavaScript>]
        member this.JQuery = JQuery.Of(this.Dom)


module Styles = 
    type StickyNotes() = 
        inherit Resources.BaseResource("StickyNotes.css")

module State = 
    
    type Note = 
        { X : int
          Y : int
          Content : string }

    let private key = "StickyNotesState"
    let private doSave (notes : Note list) = 
        HttpContext.Current.Application.Set(key, notes)
        notes

    let private doLoad () = 
        match HttpContext.Current.Application.Get(key) with
        | :? list<Note> as v -> v
        | _ -> doSave []

    let private lockObj = obj()

    let save notes = lock lockObj (fun () -> doSave notes)
    let load () = lock lockObj doLoad

module Rpc = 
    [<Rpc>]
    let loadNotes () = 
        State.load ()
    
    [<Rpc>]
    let saveNotes notes = 
        State.save notes |> ignore

open State

[<Require(typeof<Styles.StickyNotes>)>]
module Notes = 
    
    open Extensions

    type pos = {top : int; left : int}

    [<Inline "$jq.position()">]
    let position (jq : JQuery) : pos = Unchecked.defaultof<_>



    [<JavaScript>]
    let notes = ref Map.empty

    // configuration data for JQuery.animate function
    type AnimateConfiguration = { opacity : float }

    [<JavaScript>]
    let main () =
        
        // moves specified element to the top in z-order 
        let maxZ = ref 0
        let bringToTop (e : Element) = 
            incr maxZ
            e.JQuery.Css("z-index", string (!maxZ)).Ignore

        let body = Div []

        // create 'Note' visual component and append it to body
        // if state is defined then it contains previousy stored state
        let noteId = ref 0
        let createNote (state : option<Note>)  =
            let currentId = !noteId
            incr noteId

            let edit = Div [ Attr.Class "edit" ]
            edit.JQuery.Attr("contenteditable", "true").Ignore

            let close = Div [Attr.Class "closebutton"] 
            let rec note = 
                Div [Attr.Class "note"] -< [ 
                    Div [Attr.Class "header"] |>! OnMouseDown (fun _ _ -> bringToTop note)
                    close
                    edit 
                    ]

            close |> OnClick(fun _ _ -> 
                        note.JQuery.Animate({opacity=0.3}, 300, "linear", (fun () -> 
                        notes := Map.remove currentId !notes 
                        note.Remove()
                        )).Ignore
                )

            // make element draggable
            JQueryUI.Draggable.New(note, JQueryUI.DraggableConfiguration(Handle = ".header")) |> ignore
            notes := Map.add currentId (note, edit) !notes
                        
            match state with
            | Some(n) ->
                edit.Append n.Content
                note.JQuery.
                    Css("left", string n.X + "px").
                    Css("top", string n.Y + "px").
                    Ignore

            | _ -> 
                ()
                            
            body.Append(note)
        
        // saves current snapshot of notes in server storage
        let saveNotes (el : Element) (_ : Events.MouseEvent) = 
            el.SetAttribute("disabled", "true") 
            el.Text <- "Saving..."

            !notes
                |> Seq.map(fun kv  -> 
                        let n,e = kv.Value
                        let pos =  position n.JQuery
                        { X = pos.left; Y = pos.top; Content = e.Html }
                    )
                |> Seq.toList
                |> Rpc.saveNotes

            el.Text <- "Save"
            el.RemoveAttribute("disabled")


        // restore previous state
        let notes = Rpc.loadNotes()
        for n in notes do
            createNote (Some n)
        
        Table [
            TR [
                TD [ Width "30"] -< [Button [Text "Create"] |>! OnClick(fun _ _ -> createNote None) ] 
                TD [ Button [Text "Save" ] |>! OnClick saveNotes ] 
               ]
            TR [TD [ColSpan "2" ] -< [body] ]
        ]

type Body() = 
    inherit Web.Control()
    [<JavaScript>]
    override this.Body = 
        Notes.main () :> _