namespace WebSharperProject

open IntelliFactory.WebSharper

type CodeMirrorResources() = 
    inherit Resources.BaseResource("", "", [|"Scripts/codemirror.js"; "Scripts/mirrorframe.js"; "css/docs.css"|])

[<Require(typeof<CodeMirrorResources>)>]    
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
