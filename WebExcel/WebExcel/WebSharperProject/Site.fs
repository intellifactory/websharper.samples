namespace WebExcel

type Actions =
    | Main
    | DownloadWorksheet

open IntelliFactory.Html
open IntelliFactory.WebSharper.Sitelets

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Content = 
    let json = IntelliFactory.Json.Json.New()
    let Json v = 
        CustomContent <| fun _ ->
            {
                Status = Http.Status.Ok
                Headers = 
                    [
                        Http.Header.Custom "content-type" "application/json"
                    ] 
                WriteBody = fun stream ->
                    let w = new System.IO.StreamWriter(stream)
                    json.Write w v
                    w.Flush()
            }

module Site =
    let private mainPage = 
        PageContent <| fun _ ->
            {
                Page.Default
                with
                    Title = Some "WebExcel"
                    Body = [ Div [ new ExcelControl() ] ]
            }

    let private download () = 
        match Server.Get() with
        | Some v -> Content.Json v
        | None -> Content.NotFound

    let Sitelet = 
        Sitelet.Content "/" Main mainPage <|>
        Sitelet.Infer (function
            | Main -> mainPage
            | DownloadWorksheet -> download ())

type Website() =
    interface IWebsite<Actions> with
        member this.Sitelet = Site.Sitelet
        member this.Actions = []

[<assembly:Website (typeof<Website>) >]
do()

