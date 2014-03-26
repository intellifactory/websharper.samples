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
        let isAtHome = ref true
                        
        Events.deviceReady.add <| fun () ->
            JavaScript.Log("==> deviceReady")
            Mobile.Events.PageBeforeChange.On(JQuery.Of Dom.Document.Current, fun (e, data) ->
                match data.ToPage with
                | :? string as pageUrl ->
                    let hashIndex = pageUrl.IndexOf("#")
                    if hashIndex < 0 then e.PreventDefault() else
                    let pageRef = pageUrl.[hashIndex ..]
                    isAtHome := pageRef = "#home"
                    match Client.GetJQMPage pageRef with
                    | Some pageObj ->
                        let body = JQuery.Of "body"
                        let toPage =
                            match body.Children pageRef with
                            | p when p.Length = 0 ->
                                let page = pageObj.Html
                                body.Append page.Body |> ignore
                                (page :> IPagelet).Render()
                                JQuery.Of page.Body
                            | p -> p
                        !currentPage |> Option.iter (fun (p: Client.JQMPage) -> p.Unload())
                        pageObj.Load()
                        currentPage := Some pageObj
                    | None _ -> e.PreventDefault()
                | _ -> ()
            )
                                                                              
            Mobile.Events.SwipeRight.On(JQuery.Of Dom.Document.Current, fun _ ->
                if not !isAtHome then
                    Html5.Window.Self.History.Back()
            )

            Mobile.Events.SwipeLeft.On(JQuery.Of Dom.Document.Current, fun _ ->
                Html5.Window.Self.History.Forward()
            )

            PageContainer.Change(JQuery.Of ":mobile-pagecontainer", "#home", ChangePageConfig())
