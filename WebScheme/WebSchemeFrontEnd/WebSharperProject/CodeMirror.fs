namespace WebSharperProject

open IntelliFactory.WebSharper

type CodeMirrorResources() =
    inherit Resources.BaseResource("/CodeMirror", "/codemirror.js", "/mirrorframe.js")

type StyleResource() =
    inherit Resources.BaseResource("/css", "/docs.css")

[<Require(typeof<CodeMirrorResources>)>]
[<Require(typeof<StyleResource>)>]
module CodeMirror =

    type Editor = class end

    [<Inline "$e.getCode()">]
    let getCode (e : Editor): string = failwith "no dynamic invokation"

    type EditorOptions [<Inline "{}">]() =
        [<DefaultValue; Name "height">]
        val mutable Height : string

        [<DefaultValue; Name "content">]
        val mutable Content : string

        [<DefaultValue; Name "stylesheet">]
        val mutable StyleSheet : string

        [<DefaultValue; Name "path">]
        val mutable Path : string

        [<DefaultValue; Name "parserfile">]
        val mutable ParserFile : string array

        [<DefaultValue; Name "autoMatchParens">]
        val mutable AutoMatchParens : bool

        [<DefaultValue; Name "disableSpellcheck">]
        val mutable DisableSpellcheck : bool

        [<DefaultValue; Name "lineNumbers">]
        val mutable LineNumbers : bool

    [<Inline("new CodeMirror(CodeMirror.replace($node), $options)")>]
    let create (node : Dom.Element) (options : EditorOptions) : Editor = failwith "no dynamic invokation"
