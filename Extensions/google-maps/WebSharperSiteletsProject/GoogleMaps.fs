(*!Google Maps!*)
(*![
    <p>This example demonstrates how you can embed Google Map controls in
    your applications. It demonstrate a number of common scenarios,
    including simple maps with navigational controls, markers, custom
    events, and street views.</p>
    <h2>Source Code Explained</h2>
]*)
namespace WebSharperSiteletsProject

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.Google.Maps

module GoogleMaps =
    open IntelliFactory.WebSharper.EcmaScript

    [<JavaScript>]
    let Sample buildMap =
        Div [Attr.Style "padding-bottom:20px; width:500px; height:300px;"]
        |>! OnAfterRender (fun mapElement ->
            let center = new LatLng(37.4419, -122.1419)
            let options = new MapOptions(8, center, MapTypeId.ROADMAP)
            let map = new Google.Maps.Map(mapElement.Body, options)
            buildMap map)

    (*![
        <p>The simplest example. Just add the map and set the center to
        Palo Alto.</p>
    ]*)
    [<JavaScript>]
    let SimpleMap() =
        Sample <| fun (map: Map) ->
            let latLng = new LatLng(37.4419, -122.1419)
            let options = new MapOptions(8, latLng, MapTypeId.ROADMAP)
            map.SetOptions options

    [<JavaScript>]
    let PanTo() =
        Sample <| fun map ->

            let center = new LatLng(37.4419, -122.1419)
            let options = new MapOptions(8, center, MapTypeId.ROADMAP)
            map.SetOptions options
            let move () = map.PanTo(new LatLng(37.4569, -122.1569))
            JavaScript.SetTimeout move 5000 |> ignore

    /// Sets 10 random markers around the map.
    [<JavaScript>]
    let RandomMarkers() =
        Sample <| fun map ->
            let addMarkers (_:obj) =
                // bounds is only available in the "bounds_changed" event.
                let bounds = map.GetBounds()
                let sw = bounds.GetSouthWest()
                let ne = bounds.GetNorthEast()
                let lngSpan = ne.Lng() - sw.Lng()
                let latSpan = ne.Lat() - sw.Lat()
                let rnd = Math.Random
                for i in 1 .. 10 do
                    let point = new LatLng(sw.Lat() + (latSpan * rnd()),
                                           sw.Lng() + (lngSpan * rnd()))
                    let markerOptions = new MarkerOptions(point)
                    markerOptions.Map <- map
                    new Marker(markerOptions) |> ignore
            Event.AddListener(map, "bounds_changed", addMarkers) |> ignore

    [<JavaScript>]
    let InfoWindow() =
        Sample <| fun map ->
            let center = map.GetCenter()
            let helloWorldElement = Span [Text "Hello World"]
            let iwOptions = new InfoWindowOptions()
            iwOptions.Content <- helloWorldElement.Body
            iwOptions.Position <- center
            let iw = new InfoWindow(iwOptions)
            iw.Open(map)

    [<JavaScript>]
    let Controls() =
        Sample <| fun map ->
            let center = new LatLng(37.4419, -122.1419)
            let options = new MapOptions(8, center, MapTypeId.ROADMAP)
            options.DisableDefaultUI <- true
            let ncOptions = new NavigationControlOptions()
            ncOptions.Style <- NavigationControlStyle.ZOOM_PAN
            options.NavigationControlOptions <- ncOptions
            options.NavigationControl <- true
            map.SetOptions options

    [<JavaScript>]
    let SimpleDirections() =
        Sample <| fun map ->
            let directionsService = new DirectionsService()
            let directionsDisplay = new DirectionsRenderer();
            map.SetCenter(new LatLng(41.850033, -87.6500523))
            map.SetZoom 7
            map.SetMapTypeId MapTypeId.ROADMAP
            let a = DirectionsRendererOptions()
            directionsDisplay.SetMap(map)
            let mapDiv = map.GetDiv()
            let dirPanel = Div [ Attr.Name "directionsDiv"]
            let j = IntelliFactory.WebSharper.JQuery.JQuery.Of(mapDiv)
            j.After(dirPanel.Body).Ignore
            directionsDisplay.SetPanel dirPanel.Body
            let calcRoute () =
                let start = "chicago, il"
                let destination  = "st louis, mo"
                let request = new DirectionsRequest(start, destination, DirectionsTravelMode.DRIVING)
                directionsService.Route(request, fun (result, status) ->
                    if status = DirectionsStatus.OK then
                        directionsDisplay.SetDirections result)
            calcRoute ()

    [<JavaScriptAttribute>]
    let DirectionsWithWaypoints() =
        Sample <| fun map ->
            let directionsService = new DirectionsService()
            let directionsDisplay = new DirectionsRenderer();
            map.SetCenter(new LatLng(41.850033, -87.6500523))
            map.SetZoom 7
            map.SetMapTypeId MapTypeId.ROADMAP
            let a = DirectionsRendererOptions()
            directionsDisplay.SetMap(map)
            let mapDiv = map.GetDiv()
            let dirPanel = Div [Attr.Name "directionsDiv"]
            let j = JQuery.JQuery.Of mapDiv
            j.After(dirPanel.Body).Ignore
            directionsDisplay.SetPanel dirPanel.Body
            let calcRoute () =
                let start = "chicago, il"
                let destination  = "st louis, mo"

                let request = new DirectionsRequest(start, destination, DirectionsTravelMode.DRIVING)
                let waypoints =
                    [|"champaign, il"
                      "decatur, il"  |]
                    |> Array.map (fun x ->
                                    let wp = new DirectionsWaypoint()
                                    wp.Location <- x
                                    wp)

                request.Waypoints <- waypoints
                directionsService.Route(request, fun (result, status) ->
                    if status = DirectionsStatus.OK then
                        directionsDisplay.SetDirections result)
            calcRoute ()

    [<JavaScriptAttribute>]
    /// Since it's not available in v3. We make it using the ImageMapType
    /// Taken from: http://code.google.com/p/gmaps-samples-v3/source/browse/trunk/planetary-maptypes/planetary-maptypes.html?r=206
    let Moon() =
        Sample <| fun map ->
            //Normalizes the tile URL so that tiles repeat across the x axis (horizontally) like the
            //standard Google map tiles.
            let getHorizontallyRepeatingTileUrl(coord: Point, zoom: int, urlfunc: (Point * int -> string)) : string =
                let mutable x = coord.X
                let y = coord.Y
                let tileRange = float (1 <<< zoom)
                if (y < 0. || y >= tileRange)
                then null
                else
                    if x < 0. || x >= tileRange
                    then x <- (x % tileRange + tileRange) % tileRange
                    urlfunc(new Point(x, y), zoom)

            let itOptions = new ImageMapTypeOptions()

            itOptions.GetTileUrl <-
                (fun _ coord zoom ->
                    getHorizontallyRepeatingTileUrl (coord, zoom,
                        (fun (coord, zoom) ->
                            let bound = Math.Pow(float 2, float zoom)
                            ("http://mw1.google.com/mw-planetary/lunar/lunarmaps_v1/clem_bw/"
                              + (string zoom) + "/" + (string coord.X) + "/" + (string (bound - coord.Y - 1.) + ".jpg")))))

            itOptions.TileSize <- new Size(256., 256.)
            itOptions.IsPng <- false
            itOptions.MaxZoom <- 9
            itOptions.MinZoom <- 0
            itOptions.Name <- "Moon"

            let it = new ImageMapType(itOptions)
            it.Radius <- 1738000.
            let center = new LatLng(0., 0.)
            let mapIds = [| box "Moon" |> unbox |]
            let mapControlOptions =
                let mco = new MapTypeControlOptions()
                mco.Style <- MapTypeControlStyle.DROPDOWN_MENU
                mco.MapTypeIds <- mapIds
                mco

            let options = new MapOptions(0, center, mapIds.[0])
            options.MapTypeControlOptions <- mapControlOptions
            map.SetOptions options
            JavaScript.Set map.MapTypes "Moon" it 
            // TODO: Add the credit part
            ()

    /// Example using custom icons.
    [<JavaScript>]
    let Weather() =
        Sample <| fun map ->
            let images = [| "sun"; "rain"; "snow"; "storm" |]
            let getWeatherIcon () =
                let i = int <| Math.Floor(float images.Length * Math.Random())
                let icon = new MarkerImage("http://gmaps-utility-library.googlecode.com/svn/trunk/markermanager/release/examples/images/"
                                            + images.[i] + ".png")
                icon

            let addMarkers (_:obj) =
                let bounds = map.GetBounds()
                let sw = bounds.GetSouthWest()
                let ne = bounds.GetNorthEast()
                let lngSpan = ne.Lng() - sw.Lng()
                let latSpan = ne.Lat() - sw.Lat()
                let rnd = Math.Random
                for i in 1..10 do
                    let point = new LatLng(sw.Lat() + (latSpan * rnd()),
                                           sw.Lng() + (lngSpan * rnd()))
                    let markerOptions = new MarkerOptions(point)
                    markerOptions.Icon <- getWeatherIcon()
                    markerOptions.Map <- map
                    new Marker(markerOptions) |> ignore

            Event.AddListener(map, "bounds_changed", addMarkers) |> ignore

    [<JavaScript>]
    let SimplePolygon() =
        Sample <| fun map ->
            map.SetCenter(new LatLng(37.4419, -122.1419))
            map.SetZoom(13)
            let polygon = new Polygon()
            let coords = [| new LatLng(37.4419, -122.1419)
                            new LatLng(37.4519, -122.1519)
                            new LatLng(37.4419, -122.1319)
                            new LatLng(37.4419, -122.1419) |]
            polygon.SetPath coords
            polygon.SetMap map

    /// Example for a combined map and panorama using a reference point.
    [<JavaScript>]
    let StreetView() =
        Sample <| fun map ->
            let fenwayPark = new LatLng(42.345573, -71.098623)
            map.SetCenter(fenwayPark)
            map.SetZoom(15)
            let marker = new Marker()
            marker.SetPosition fenwayPark
            marker.SetMap map
            let options = new MapOptions(14, fenwayPark, MapTypeId.ROADMAP)
            options.StreetViewControl <- true
            map.SetOptions options

    [<JavaScript>]
    let PrimitiveEvent () =
        Sample <| fun map ->
            let clickAction (_:obj) = JavaScript.Alert "Map Clicked!"
            Event.AddListener(map, "click", clickAction)
            |> ignore

    [<JavaScript>]
    let SimplePolyline() =
        Sample <| fun map ->
            let coords = [| new LatLng(37.4419, -122.1419)
                            new LatLng(37.4519, -122.1519)|]
            let polylineOptions = new PolylineOptions()
            polylineOptions.StrokeColor <- "#ff0000"
            polylineOptions.Path <- coords
            polylineOptions.Map <- map
            new Polyline(polylineOptions)
            |> ignore

    [<JavaScript>]
    let Main ()=
        Div [
            H3 [Text "Simple map"]
            P [Text "The simplest example. Just a map \
                        centered at Palo Alto."]
            SimpleMap ()
            H3 [Text "Panning from a given location."]
            PanTo ()
            H3 [Text "Random markers"]
            P [Text "Sets 10 random markers around the map."]
            RandomMarkers ()
            H3 [Text "Info window"]
            InfoWindow ()
            H3 [Text "Controls"]
            P [Text "Creates and adds simple controls to the map."]
            Controls ()
            H3 [Text "Simple directions"]
            SimpleDirections ()
            H3 [Text "Directions with waypoints"]
            DirectionsWithWaypoints ()
            H3 [Text "Moon"]
            P [Text "Uses the Moon's map instead of the Earth's."]
            Moon ()
            H3 [Text "Weather"]
            P [Text "Example using custom icons."]
            Weather ()
            H3 [Text "Simple polygon"]
            P [Text "Draws a simple triangle."]
            SimplePolygon ()
            H3 [Text "Street view"]
            StreetView ()
            H3 [Text "Primitive events"]
            P [Text "Listens to events on the map."]
            PrimitiveEvent ()
            H3 [Text "Simple polyline"]
            SimplePolyline ()
    ]

type GoogleMapsViewer() =
    inherit Web.Control()
    [<JavaScript>]
    override this.Body = GoogleMaps.Main () :> _