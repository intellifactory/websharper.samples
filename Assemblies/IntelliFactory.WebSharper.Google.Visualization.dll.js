(function()
{
  var global = this;
  var AnnotatedTimeLine, AreaChart, BarChart, Base, Cell, ColumnChart, Events,
      Formatters, GeoMap, IntensityMap, LineChart, MotionChart, OrgChart,
      PieChart, ScatterChart, Table, TreeMap, Visualizations, WebSharper, _, __1,
      __2, __3, __4, event, events;
  IntelliFactory.WebSharper.Runtime.Declare({IntelliFactory:
                                             {WebSharper:
                                              {Google:
                                               {Visualization:
                                                {Visualizations:
                                                 {
                                                   TableOptions:
                                                     {},
                                                   TableCSSClasses:
                                                     {},
                                                   ScatterChartOptions:
                                                     {},
                                                   PieChartOptions:
                                                     {},
                                                   OrgChartOptions:
                                                     {},
                                                   MotionChartOptions:
                                                     {},
                                                   LineChartOptions:
                                                     {},
                                                   IntensityMapOptions:
                                                     {},
                                                   GeoMapOptions:
                                                     {},
                                                   GaugeOptions:
                                                     {},
                                                   ColumnChartOptions:
                                                     {},
                                                   BarChartOptions:
                                                     {},
                                                   AreaChartOptions:
                                                     {},
                                                   AnnotatedTimeLineOptions:
                                                     {}
                                                 },
                                                 Formatters:
                                                 {DateFormatOptions: {},
                                                  BarFormatOptions: {}},
                                                 Events: {
                                                           TreeMap:
                                                             {},
                                                           Table:
                                                             {},
                                                           ScatterChart:
                                                             {},
                                                           PieChart:
                                                             {},
                                                           OrgChart:
                                                             {},
                                                           MotionChart:
                                                             {},
                                                           LineChart:
                                                             {},
                                                           IntensityMap:
                                                             {},
                                                           GeoMap:
                                                             {},
                                                           ColumnChart:
                                                             {},
                                                           BarChart:
                                                             {},
                                                           AreaChart:
                                                             {},
                                                           AnnotatedTimeLine:
                                                             {}
                                                         },
                                                 Base: {Helpers: {}, Cell: {}}}}}}});
  TreeMap =
  function()
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.TreeMap;
  };
  Events = function()
           {
             return IntelliFactory.WebSharper.Google.Visualization.Events;
           };
  (function()
   {
     return IntelliFactory.WebSharper.Google.Visualization;
   });
  (function()
   {
     return IntelliFactory.WebSharper.Google;
   });
  WebSharper = function()
               {
                 return IntelliFactory.WebSharper;
               };
  _ =
  function(visualization)
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.event(visualization,
                                                                       "ready");
  };
  event = function()
          {
            return IntelliFactory.WebSharper.Google.Visualization.Events.event;
          };
  __1 =
  function(visualization)
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.event(visualization,
                                                                       "select");
  };
  __2 =
  function(visualization)
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.event(visualization,
                                                                       "onmouseover");
  };
  __3 =
  function(visualization)
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.event(visualization,
                                                                       "onmouseout");
  };
  Table = function()
          {
            return IntelliFactory.WebSharper.Google.Visualization.Events.Table;
          };
  OrgChart =
  function()
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.OrgChart;
  };
  MotionChart =
  function()
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.MotionChart;
  };
  IntensityMap =
  function()
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.IntensityMap;
  };
  GeoMap =
  function()
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.GeoMap;
  };
  ScatterChart =
  function()
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.ScatterChart;
  };
  PieChart =
  function()
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.PieChart;
  };
  LineChart =
  function()
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.LineChart;
  };
  ColumnChart =
  function()
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.ColumnChart;
  };
  BarChart =
  function()
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.BarChart;
  };
  AreaChart =
  function()
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.AreaChart;
  };
  AnnotatedTimeLine =
  function()
  {
    return IntelliFactory.WebSharper.Google.Visualization.Events.AnnotatedTimeLine;
  };
  Visualizations =
  function()
  {
    return IntelliFactory.WebSharper.Google.Visualization.Visualizations;
  };
  __4 = function()
        {
          return {};
        };
  Formatters =
  function()
  {
    return IntelliFactory.WebSharper.Google.Visualization.Formatters;
  };
  Cell = function()
         {
           return IntelliFactory.WebSharper.Google.Visualization.Base.Cell;
         };
  Base = function()
         {
           return IntelliFactory.WebSharper.Google.Visualization.Base;
         };
  events = function()
           {
             return google.visualization.events;
           };
  (function()
   {
     return google.visualization;
   });
  TreeMap().Ready = _;
  TreeMap().Select = __1;
  TreeMap().OnMouseOver = __2;
  TreeMap().OnMouseOut = __3;
  Table().Ready = _;
  Table().Select = __1;
  Table().Page = function(visualization)
                 {
                   return event()(visualization, "page");
                 };
  Table().Sort = function(visualization)
                 {
                   return event()(visualization, "sort");
                 };
  OrgChart().Collapse = function(visualization)
                        {
                          return event()(visualization, "collapse");
                        };
  OrgChart().OnMouseOver = __2;
  OrgChart().OnMouseOut = __3;
  OrgChart().Select = __1;
  OrgChart().Ready = _;
  MotionChart().Ready = _;
  MotionChart().StateChange = function(visualization)
                              {
                                return event()(visualization, "statechange");
                              };
  IntensityMap().Select = __1;
  IntensityMap().Ready = function(visualization)
                         {
                           return event()(visualization, "Ready");
                         };
  GeoMap().Select = __1;
  GeoMap().RegionClick = function(visualization)
                         {
                           return event()(visualization, "regionClick");
                         };
  GeoMap().ZoomOut = function(visualization)
                     {
                       return event()(visualization, "zoomOut");
                     };
  GeoMap().DrawingDone = function(visualization)
                         {
                           return event()(visualization, "drawingDone");
                         };
  ScatterChart().Ready = _;
  ScatterChart().Select = __1;
  ScatterChart().OnMouseOver = __2;
  ScatterChart().OnMouseOut = __3;
  PieChart().Ready = _;
  PieChart().Select = __1;
  PieChart().OnMouseOver = __2;
  PieChart().OnMouseOut = __3;
  LineChart().Ready = _;
  LineChart().Select = __1;
  LineChart().OnMouseOver = __2;
  LineChart().OnMouseOut = __3;
  ColumnChart().Ready = _;
  ColumnChart().Select = __1;
  ColumnChart().OnMouseOver = __2;
  ColumnChart().OnMouseOut = __3;
  BarChart().Ready = _;
  BarChart().Select = __1;
  BarChart().OnMouseOver = __2;
  BarChart().OnMouseOut = __3;
  AreaChart().Ready = _;
  AreaChart().Select = __1;
  AreaChart().OnMouseOver = __2;
  AreaChart().OnMouseOut = __3;
  AnnotatedTimeLine().RangeChange =
  function(visualization)
  {
    return event()(visualization, "rangechange");
  };
  AnnotatedTimeLine().Ready = _;
  AnnotatedTimeLine().Select = __1;
  Visualizations().ScatterChartOptions.get_Default = __4;
  Visualizations().PieChartOptions.get_Default = __4;
  Visualizations().OrgChartOptions.get_Default = __4;
  Visualizations().MotionChartOptions.get_Default = __4;
  Visualizations().LineChartOptions.get_Default = __4;
  Visualizations().IntensityMapOptions.get_Default = __4;
  Visualizations().GeoMapOptions.get_Default = __4;
  Visualizations().GaugeOptions.get_Default = __4;
  Formatters().DateFormatOptions.get_Default = __4;
  Formatters().BarFormatOptions.get_Default = __4;
  Visualizations().ColumnChartOptions.get_Default = __4;
  Visualizations().BarChartOptions.get_Default = __4;
  Visualizations().AreaChartOptions.get_Default = __4;
  Visualizations().AnnotatedTimeLineOptions.get_Default = __4;
  Visualizations().TableOptions.get_Default = __4;
  Visualizations().TableCSSClasses.get_Default = __4;
  Cell().get_Empty = __4;
  Cell().Value = function(value)
                 {
                   var inputRecord;
                   inputRecord = Cell().get_Empty();
                   return {v: value, f: inputRecord.f, p: inputRecord.p};
                 };
  Base().Helpers.X = function()
                     {
                       return undefined;
                     };
  Events().event = function(target, eventName)
                   {
                     var __6, __7, ev;
                     ev = new (WebSharper().Control["FSharpEvent`1"])();
                     __7 = function(arg00)
                           {
                             var __5;
                             __5 = ev.event;
                             return __5.Trigger(arg00);
                           };
                     __6 = events();
                     events().addListener.call(__6, target, eventName, __7);
                     return ev.event;
                   };
}())
