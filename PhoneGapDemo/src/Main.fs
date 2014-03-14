namespace PhoneGapDemo

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.JQuery
open IntelliFactory.WebSharper.JQuery.Mobile
open IntelliFactory.WebSharper.PhoneGap
open IntelliFactory.WebSharper.Sitelets

[<JavaScript>]
module Main =

    let Program =
        JavaScript.Log("==> starting Program")
        let currentPage = ref None
        Events.deviceReady.add <| fun () ->
            JavaScript.Log("==> deviceReady")
            Mobile.Events.PageBeforeChange.On(JQuery.Of Dom.Document.Current, fun (e, data) ->
                match data.ToPage with
                | :? string as pageUrl ->
                    match Client.GetJQMPage pageUrl with
                    | Some pageObj ->
                        let body = JQuery.Of "body"
                        let toPage =
                            match body.Children pageUrl with
                            | p when p.Length = 0 ->
                                let page = pageObj.Html
                                body.Append page.Body |> ignore
                                (page :> IPagelet).Render()
                                JQuery.Of page.Body
                            | p -> p
                        !currentPage |> Option.iter (fun (p: Client.JQMPage) -> p.Unload())
                        pageObj.Load()
                        currentPage := Some pageObj
                    | None _ -> ()
                | _ -> ())
            Client.mobile.ChangePage "#home"
