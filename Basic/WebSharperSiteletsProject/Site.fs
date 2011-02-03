namespace WebSharperSiteletsProject

open System
open System.IO
open System.Web

open IntelliFactory.Html
open IntelliFactory.WebSharper.Sitelets
open IntelliFactory.WebSharper

type Samples =
    | Index
    | Sample of string

module Controls =
    let list =
        typeof<Samples>.Assembly.GetTypes()
        |> Seq.filter (fun t -> typeof<Web.Control>.IsAssignableFrom t)
        |> Seq.map (fun t ->
            let name = t.Name.Substring(0, t.Name.Length - "Viewer".Length)
            name, t
            )
        |> List.ofSeq

module Site =
    let pages =
        Controls.list
            |> List.map (fun (name, t) ->
                let el = Activator.CreateInstance(t) :?> Web.Control
                let page = Website.Templates.Templates.SamplePage.SamplePage (Some name) <|
                                {
                                    Back = fun ctx -> [A [HRef (ctx.Link Index)] -< [Text "Back"]]
                                    Caption = fun _ -> [Div [Text name]]
                                    Content = fun _ -> [Div [el]]
                                }
                name, page
                )
            |> Map.ofSeq
    let index = Website.Templates.Templates.SamplePage.SamplePage (Some "Index") <|
                    {
                        Back = fun _ -> []
                        Caption = fun _ -> [Div [Text "Samples"]]
                        Content = fun ctx ->
                            [
                                Table [
                                    for name, _ in Controls.list do
                                        yield TR [ TD [ A [HRef (ctx.Link (Sample name))] -< [Text name] ]]
                                ]
                            ]
                    }

    let controller =
        let handler = function
            | Index -> index
            | Sample s -> pages.[s]

        { Handle = handler }

type Website() =
    interface IWebsite<Samples> with
        member this.Actions = []
        member this.Sitelet =
            {
                Controller = Site.controller
                Router = Router.Table [Index, "/"] <|> Router.Infer()
            }


[<assembly: WebsiteAttribute(typeof<Website>)>]
do ()