namespace PhoneGapDemo

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.JQuery
open IntelliFactory.WebSharper.JQuery.Mobile
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.PhoneGap

[<JavaScript>]
module Client =

    let mobile = Mobile.Instance

    let HeaderDiv cont =
        Div [ HTML5.Attr.Data "role" "header" ] -< cont

    let ContentDiv cont =
        Div [ HTML5.Attr.Data "role" "content" ] -< cont

    let PageDiv id' cont =
        Div [ HTML5.Attr.Data "role" "page"; Id id' ] -< cont
        |>! OnAfterRender (fun el ->
            JQuery.Of el.Body |> Mobile.Page.Init)

    let HeaderWithBackBtnDiv cont =
        HeaderDiv [ HTML5.Attr.Data "add-back-btn" "true" ] -< cont

    let ListViewUL cont =
        UL [
            HTML5.Attr.Data "role" "listview"
            HTML5.Attr.Data "inset" "true"
        ] -< cont

    let Row text value =
        TR [
            TD [ Div [ Text text ] ]
            TD [ value ]
        ]

    type JQMPage =
        {
            Html : Element
            Load : unit -> unit
            Unload : unit -> unit
        }

        static member Create(html) =
            {
                Html = html
                Load = ignore
                Unload = ignore
            }

    let WithLoad load page =
        { page with Load = load }

    let WithUnload unload page =
        { page with Unload = unload }

    let ChangePage (page: string) =
        mobile.ChangePage(page, ChangePageConfig(Transition = "slide"))

    let HomePage =
        let link text (page: string) =
            LI [
                A [ HRef ""; Text text ]
                |>! OnClick (fun _ _ -> ChangePage page)
            ]
        JQMPage.Create <|
            PageDiv "home" [
                HeaderDiv [ H1 [ Text "PhoneGap API Demo" ] ]
                ContentDiv [
                    H2 [ Text "Examples:" ]
                    ListViewUL [
                        link "Accelerometer" "#accelerometer"
                        link "Camera" "#camera"
                        link "Compass" "#compass"
                        link "GPS" "#gps"
                        link "Contacts" "#contacts"
                    ]
                ]
            ]

    let CreatePluginPage id header getPlugin makePage =
        let plugin = try Some (getPlugin ()) with _ -> None
        match plugin with
        | None ->
            JQMPage.Create <|
                PageDiv id [
                    HeaderWithBackBtnDiv [ H1 [ Text header ] ]
                    ContentDiv [ Text "Plugin not available" ]
                ]
        | Some plugin ->
            let page = makePage plugin
            {
                page with
                    Html =
                        PageDiv id [
                            HeaderWithBackBtnDiv [ H1 [ Text header ] ]
                            page.Html
                        ]
            }

    let AccelerometerPage =
        lazy
        CreatePluginPage "accelerometer" "Accelerometer" DeviceMotion.getPlugin <| fun plugin ->
            let xDiv, yDiv, zDiv = Div [], Div [], Div []
            let watchHandle = ref null
            JQMPage.Create <| ContentDiv [
                Table [
                    Row "X: " xDiv
                    Row "Y: " yDiv
                    Row "Z: " zDiv
                ]
            ]
            |> WithLoad (fun () ->
                watchHandle :=
                    plugin.watchAcceleration((fun acc ->
                        xDiv.Text <- string acc.x
                        yDiv.Text <- string acc.y
                        zDiv.Text <- string acc.z), ignore))
            |> WithUnload (fun () ->
                plugin.clearWatch(!watchHandle))

    let CameraPage =
        lazy
        CreatePluginPage "camera" "Camera" Camera.getPlugin <| fun plugin ->
            let img = Img [ Attr.Style "width: 200px" ]
            let plugin = Camera.getPlugin()
            let popoverHandle = ref null
            JQMPage.Create <| ContentDiv [
                Button [ Text "Get picture" ]
                |>! OnClick (fun _ _ ->
                    let opts = Camera.Options()
                    opts.encodingType <- Camera.EncodingType1.JPEG
                    opts.destinationType <- Camera.DestinationType1.FILE_URI
                    plugin.getPicture((fun fileURI ->
                        img.SetAttribute("src", fileURI)),
                        ignore,
                        opts)
                    |> ignore)
                img
            ]

    let CompassPage =
        lazy
        CreatePluginPage "compass" "Compass" DeviceOrientation.getPlugin <| fun plugin ->
            let headingDiv = Div []
            let plugin = DeviceOrientation.getPlugin()
            let watchHandle = ref null
            JQMPage.Create <| ContentDiv [
                Div [ Text "Heading:" ]
                headingDiv
            ]
            |> WithLoad (fun () ->
                watchHandle :=
                    plugin.watchHeading((fun ori ->
                        headingDiv.Text <- string ori.magneticHeading),
                        ignore))
            |> WithUnload (fun () ->
                plugin.clearWatch(!watchHandle))

    let GPSPage =
        lazy
        CreatePluginPage "gps" "GPS" Geolocation.getPlugin <| fun plugin ->
            let latDiv, lngDiv, altDiv = Div[], Div[], Div[] 
            let plugin = Geolocation.getPlugin()
            let watchHandle = ref null
            JQMPage.Create <| ContentDiv [
                Table [
                    Row "Latitude: " latDiv
                    Row "Longitude: " lngDiv
                    Row "Altitude: " altDiv
                ]
            ]
            |> WithLoad (fun () ->
                watchHandle :=
                    plugin.watchPosition((fun pos ->
                        latDiv.Text <- string pos.coords.latitude
                        lngDiv.Text <- string pos.coords.longitude
                        altDiv.Text <- string pos.coords.altitude),
                        ignore))
            |> WithUnload (fun () ->
                plugin.clearWatch(!watchHandle))

    let ContactsPage =
        lazy
        CreatePluginPage "contacts" "Contacts" Contacts.getPlugin <| fun plugin ->
            let contactsUL = ListViewUL []
            let plugin = Contacts.getPlugin()
            JQMPage.Create <| ContentDiv [ contactsUL ]
            |> WithLoad (fun () ->
                contactsUL.Clear()
                let onFound (cts: Contacts.Contact []) =
                    let cts =
                        cts
                        |> Array.filter (fun c -> As c.displayName)
                    for c in cts do
                        LI [ Text c.displayName ]
                        |> contactsUL.Append
                    JQuery.Of contactsUL.Body |> Mobile.ListView.Refresh
                plugin.find([| "displayName" |], onFound, ignore,
                    Contacts.FindOptions(multiple = true)))

    let GetJQMPage pageRef =
        match pageRef with
        | "#home" -> Some HomePage
        | "#accelerometer" -> Some AccelerometerPage.Value
        | "#camera" -> Some CameraPage.Value
        | "#compass" -> Some CompassPage.Value
        | "#gps" -> Some GPSPage.Value
        | "#contacts" -> Some ContactsPage.Value
        | _ -> None
