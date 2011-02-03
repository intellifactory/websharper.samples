(*!Google Maps!*)
(*![
    <p>This example demonstrates how you can embed Google Visualization controls in
    your applications. It contains examples using:</p>
    <ul>
        <li>Motion Chart</li>
        <li>Intensity Map</li>
        <li>Custom GeoMap</li>
        <li>Line Chart</li>
        <li>Bar Chart</li>
        <li>Gauge</li>
        <li>Area Chart</li>
    </ul>
    <h2>Source Code Explained</h2>
]*)
namespace WebSharperSiteletsProject 

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.Google
open IntelliFactory.WebSharper.Google.Visualization
open IntelliFactory.WebSharper.Google.Visualization.Base
open IntelliFactory.WebSharper.EcmaScript

type Color = Visualizations.Color

module GoogleVisualization =
    module Data =

        [<JavaScript>]
        let TableData () =
            let data = new Base.DataTable()
            data.addColumn(ColumnType.StringType, "Name") |> ignore
            data.addColumn(ColumnType.NumberType, "Height") |> ignore
            data.addRows(3) |> ignore
            data.setCell(0, 0, "Tong Ning mu") |> ignore
            data.setCell(1, 0, "Huang Ang fa") |> ignore
            data.setCell(2, 0, "Teng nu") |> ignore
            data.setCell(0, 1, 174.) |> ignore
            data.setCell(1, 1, 523.) |> ignore
            data.setCell(2, 1, 86.) |> ignore
            data

        [<JavaScript>]
        let ATLData () =
            let data = new Base.DataTable()
            data.addColumn(ColumnType.DateType, "Name") |> ignore
            data.addColumn(ColumnType.NumberType, "Sold pencils") |> ignore
            data.addColumn(ColumnType.StringType, "Title") |> ignore
            data.addRows 6 |> ignore

            data.setCell(0, 0, new Date(2008, 1, 1)) |> ignore
            data.setCell(1, 0, new Date(2008, 1, 2)) |> ignore
            data.setCell(2, 0, new Date(2008, 1, 3)) |> ignore
            data.setCell(3, 0, new Date(2008, 1, 4)) |> ignore
            data.setCell(4, 0, new Date(2008, 1, 5)) |> ignore
            data.setCell(5, 0, new Date(2008, 1, 6)) |> ignore

            data.setCell(0, 1, 30000.) |> ignore
            data.setCell(1, 1, 14045.) |> ignore
            data.setCell(2, 1, 55022.) |> ignore
            data.setCell(3, 1, 75284.) |> ignore
            data.setCell(4, 1, 41476.) |> ignore
            data.setCell(5, 1, 33322.) |> ignore

            data.setCell(3, 2, "Bought pencils") |> ignore
            data

        [<JavaScript>]
        let AreaChartData () =
            let data = new Base.DataTable()
            data.addColumn(ColumnType.StringType, "Year") |> ignore
            data.addColumn(ColumnType.NumberType, "Sales") |> ignore
            data.addColumn(ColumnType.NumberType, "Expenses") |> ignore
            data.addRows(4) |> ignore
            data.setValue(0, 0, "2004")
            data.setValue(0, 1, 1000)
            data.setValue(0, 2, 400)
            data.setValue(1, 0, "2005")
            data.setValue(1, 1, 1170)
            data.setValue(1, 2, 460)
            data.setValue(2, 0, "2006")
            data.setValue(2, 1, 660)
            data.setValue(2, 2, 1120)
            data.setValue(3, 0, "2007")
            data.setValue(3, 1, 1030)
            data.setValue(3, 2, 540)
            data

        [<JavaScript>]
        let GaugeData () =
            let data = new Base.DataTable()
            data.addColumn(ColumnType.StringType, "Label") |> ignore
            data.addColumn(ColumnType.NumberType, "Value") |> ignore
            data.addRows(3) |> ignore
            data.setValue(0, 0, "Memory")
            data.setValue(0, 1, 80.)
            data.setValue(1, 0, "CPU")
            data.setValue(1, 1, 55.)
            data.setValue(2, 0, "Network")
            data.setValue(2, 1, 68.)
            data

        [<JavaScript>]
        let GeoMapData () =
            let data = new Base.DataTable()
            data.addRows(6) |> ignore
            data.addColumn(ColumnType.StringType, "Country") |> ignore
            data.addColumn(ColumnType.NumberType, "Popularity") |> ignore
            data.setValue(0, 0, "Germany")
            data.setValue(0, 1, 200)
            data.setValue(1, 0, "United States")
            data.setValue(1, 1, 300)
            data.setValue(2, 0, "Brazil")
            data.setValue(2, 1, 400)
            data.setValue(3, 0, "Canada")
            data.setValue(3, 1, 500)
            data.setValue(4, 0, "France")
            data.setValue(4, 1, 600)
            data.setValue(5, 0, "RU")
            data.setValue(5, 1, 700)
            data

        [<JavaScript>]
        let GeoMapMarkersData () =
            let data = new Base.DataTable()
            data.addRows 6 |> ignore
            data.addColumn(ColumnType.StringType, "City") |> ignore
            data.addColumn(ColumnType.NumberType, "Popularity") |> ignore
            data.setValue(0, 0, "New York")
            data.setValue(0, 1, 200)
            data.setValue(1, 0, "Boston")
            data.setValue(1, 1, 300)
            data.setValue(2, 0, "Miami")
            data.setValue(2, 1, 400)
            data.setValue(3, 0, "Chicago")
            data.setValue(3, 1, 500)
            data.setValue(4, 0, "Los Angeles")
            data.setValue(4, 1, 600)
            data.setValue(5, 0, "Houston")
            data.setValue(5, 1, 700)
            data

        [<JavaScript>]
        let IntensityMapData () =
            let data = new Base.DataTable()
            data.addColumn(ColumnType.StringType, "", "Country")
            |> ignore
            data.addColumn(ColumnType.NumberType, "Population (mil)", "a")
            |> ignore
            data.addColumn(ColumnType.NumberType, "Area (km2)", "b")
            |> ignore
            data.addRows 5 |> ignore
            data.setValue(0, 0, "CN")
            data.setValue(0, 1, 1324)
            data.setValue(0, 2, 9640821)
            data.setValue(1, 0, "IN")
            data.setValue(1, 1, 1133)
            data.setValue(1, 2, 3287263)
            data.setValue(2, 0, "US")
            data.setValue(2, 1, 304)
            data.setValue(2, 2, 9629091)
            data.setValue(3, 0, "ID")
            data.setValue(3, 1, 232)
            data.setValue(3, 2, 1904569)
            data.setValue(4, 0, "BR")
            data.setValue(4, 1, 187)
            data.setValue(4, 2, 8514877)
            data

        [<JavaScript>]
        let MotionChartData () =
            let data = new Base.DataTable()
            data.addColumn(ColumnType.StringType, "Fruit") |> ignore
            data.addColumn(ColumnType.DateType, "Date") |> ignore
            data.addColumn(ColumnType.NumberType, "Sales") |> ignore
            data.addColumn(ColumnType.NumberType, "Expenses") |> ignore
            data.addColumn(ColumnType.StringType, "Location") |> ignore
            let V: obj -> Base.Cell = Google.Visualization.Base.Cell.Value
            [| [| V "Apples" ; V (new Date (1988, 0, 1));
                  V 1000; V 300; V "East"|]
               [| V "Oranges"; V (new Date (1988, 0, 1));
                  V 1150; V 200; V "West"|]
               [| V "Bananas"; V (new Date (1988, 0, 1));
                  V 300;  V 250; V "West"|]
               [| V "Apples" ; V (new Date (1989, 6, 1));
                  V 1200; V 400; V "East"|]
               [| V "Oranges"; V (new Date (1989, 6, 1));
                  V 750;  V 150; V "West"|]
               [| V "Bananas"; V (new Date (1989, 6, 1));
                  V 788;  V 617; V "West"|] |]
            |> data.addRows
            |> ignore
            data

    /// Test for the MotionChart visualization.
    [<JavaScript>]
    let MotionChart () =
        Div []
        |>! OnAfterRender (fun container ->
            let visualization = new Visualizations.MotionChart(container.Dom)
            let options = { Visualizations.MotionChartOptions.Default
                                with width = 600.
                                     height = 300.}
            visualization.draw(Data.MotionChartData(), options))

    /// Test for the IntensityMap visualization.
    [<JavaScript>]
    let IntensityMap () =
        Div []
        |>! OnAfterRender (fun container ->
            let visualization = new Visualizations.IntensityMap(container.Dom)
            let options = { Visualizations.IntensityMapOptions.Default
                                with width = 600.
                                     height = 300.
                          }
            visualization.draw(Data.IntensityMapData(),
                               options)
            JQuery.JQuery.Of(".google-visualization-intensitymap-map").Height(250).Ignore)

    /// Test for the GeoMap visualization using markers.
    [<JavaScript>]
    let GeoMapMarkers () =
        Div []
        |>! OnAfterRender (fun container ->
            let visualization = new Visualizations.GeoMap(container.Dom)
        
            let options = {
                Visualizations.GeoMapOptions.Default with
                    width = "400px"
                    height = "240px"
                    region = Visualizations.Region.FromString "US"
                    colors = [| 0xFF8747; 0xFFB581; 0xc06000 |]
                    dataMode = Visualizations.DataMode.Markers
            }
            visualization.draw(Data.GeoMapMarkersData(), options))

    /// Test for the ColumnChart visualization.
    [<JavaScript>]
    let ColumnChart () =
        Div []
        |>! OnAfterRender (fun container ->
            let visualization = new Visualizations.ColumnChart(container.Dom)
            let options = {
                Visualizations.ColumnChartOptions.Default with
                     width = 400.
                     height = 240.
                     legend = Visualizations.LegendPosition.Bottom
                     title = "Company Performance"}
            visualization.draw(Data.AreaChartData(), options))

    /// Test for the LineChart visualization.
    [<JavaScript>]
    let LineChart () =
        Div []
        |>! OnAfterRender (fun container ->
            let visualization = new Visualizations.LineChart(container.Dom)
            let options = {
                Visualizations.LineChartOptions.Default with
                    width = 400.
                    height = 240.
                    legend = Visualizations.LegendPosition.Bottom
                    title = "Company Performance"
            }
            visualization.draw(Data.AreaChartData(), options))

    /// Test for the BarChart visualization.
    [<JavaScript>]
    let BarChart () =
        Div []
        |>! OnAfterRender (fun container ->
            let visualization = new Visualizations.BarChart(container.Dom)
            let options = {
                Visualizations.BarChartOptions.Default with
                    width = 400.
                    height = 240.
                    legend = Visualizations.LegendPosition.Bottom
                    title = "Company Performance"
                }
            visualization.draw(Data.AreaChartData(), options))

    /// Test for the Gauge visualization.
    [<JavaScript>]
    let Gauge () =
        Div []
        |>! OnAfterRender (fun container ->
            let visualization = new Visualizations.Gauge(container.Dom)
            let options = {
                Visualizations.GaugeOptions.Default with
                    width = 400.
                    height = 120.
                    redFrom = 90.
                    redTo = 100.
                    yellowFrom = 75.
                    yellowTo = 90.
                    minorTicks = 5.
            }
            visualization.draw(Data.GaugeData(), options))

    /// Test for the Area Chart class
    [<JavaScript>]
    let AreaChart () =
        Div []
        |>! OnAfterRender (fun container ->
            let visualization = new Visualizations.AreaChart(container.Dom)
            let options = {
                Visualizations.AreaChartOptions.Default with
                    width = 400.
                    height = 240.
                    legend = Visualizations.LegendPosition.Bottom
                    title = "Company Performance"
            }
            visualization.draw(Data.AreaChartData(), options))

    /// Simple table example
    [<JavaScript>]
    let TableExample () =
        Div []
        |>! OnAfterRender (fun container ->
            let visualization = new Visualizations.Table(container.Dom)
            let options = {
                Visualizations.TableOptions.Default with
                    showRowNumber = true
                    width = "600"
            }
            visualization.draw(Data.TableData(), options))

    [<JavaScript>]
    let Main () =
        Div [
            H2 [Text "Motion Chart"]
            MotionChart ()
            H2 [Text "Intensity Map"]
            IntensityMap ()
            H2 [Text "Custom GeoMap"]
            GeoMapMarkers ()
            H2 [Text "Column Chart"]
            ColumnChart ()
            H2 [Text "Line Chart"]
            LineChart ()
            H2 [Text "Bar Chart"]
            BarChart ()
            H2 [Text "Gauge"]
            Gauge ()
            H2 [Text "Area Chart"]
            AreaChart ()
            H2 [Text "Simple table with row numbers"]
            TableExample ()
            ]

type GoogleVisualizationViewer() =
    inherit Web.Control()
    [<JavaScript>]
    override this.Body = GoogleVisualization.Main () :> _