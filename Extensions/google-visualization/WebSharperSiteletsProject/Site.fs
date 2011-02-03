namespace WebSharperSiteletsProject

open System
open System.IO
open System.Web

open IntelliFactory.Html
open IntelliFactory.WebSharper.Sitelets
open IntelliFactory.WebSharper

module Site =
    type Action = | Index

    let Main =
        Templates.SamplePage.SamplePage (Some "Google Visualization") <|
            {
                Caption = fun _ -> [Div [Text "Google Visualization"]]
                Content = fun _ -> [Div [new GoogleVisualizationViewer()]]
            }
        |> Sitelet.Content "/" Index

type Website() =
    interface IWebsite<Site.Action> with
        member this.Sitelet = Site.Main
        member this.Actions = [Site.Index]

[<assembly: WebsiteAttribute(typeof<Website>)>]
do ()