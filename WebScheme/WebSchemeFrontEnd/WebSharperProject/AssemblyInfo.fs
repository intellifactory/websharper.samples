namespace WebSharperProject

open System.Web.UI

open IntelliFactory.WebSharper

[<assembly: WebResource("codemirror.js", "text/javascript")>]
[<assembly: WebResource("mirrorframe.js", "text/javascript")>]
[<assembly: WebResource("tokenizescheme.js", "text/javascript")>]
[<assembly: WebResource("parsescheme.js", "text/javascript")>]
[<assembly: WebResource("docs.css", "text/css")>]
[<assembly: WebResource("schemecolors.css", "text/css")>]
do ()
