namespace WebSharperSiteletsProject

open System
open System.IO
open System.Web

open IntelliFactory.Html
open IntelliFactory.WebSharper.Sitelets
open IntelliFactory.WebSharper

type Marker = class end

type SamplesList() = 
    static let samples = 
            typeof<Marker>.Assembly.GetTypes() 
            |> Seq.filter (fun t -> typeof<Web.Control>.IsAssignableFrom t)
            |> Seq.map (fun t -> 
                let name = t.Name.Substring(0, t.Name.Length - "Viewer".Length)
                name, t
                )
            |> List.ofSeq
    static member GetSampleNames() = samples |> Seq.map fst |> Seq.toArray
    static member internal GetSamples() = samples


module Site = 
    let pages () =
        SamplesList.GetSamples()
            |> List.map (fun (name, t) ->
                let el = Activator.CreateInstance(t) :?> Web.Control
                Website.Templates.SamplePage.SamplePage name name <|
                    {
                        Caption = fun _ -> Div [Text name]
                        Content = fun _ -> Div [el]
                    }
                )
        
    

type Website() =
    interface IWebsite with
        member this.Pages = Site.pages ()           


[<assembly: WebsiteAttribute(typeof<Website>)>]
do ()