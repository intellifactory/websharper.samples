namespace WebSharperProject

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

module ElementExtensions =
    type IntelliFactory.WebSharper.Html.Element with
        [<JavaScript>]
        member this.JQuery = JQuery.JQuery.Of(this.Dom)

open WebScheme
open ElementExtensions

type WebSchemeUI() =
    inherit Web.Control()

    [<JavaScript>]
    let rec toString = function
        | Scheme.Bool v -> v.ToString()
        | Scheme.Int v -> v.ToString()
        | Scheme.String v -> v.ToString()
        | Scheme.Function _ -> "<function>"
        | Scheme.Null -> "<null>"
        | Scheme.List l ->
            let result =
                match l with
                | [] -> ""
                | l ->
                    l
                    |> Seq.map toString
                    |> Seq.reduce (fun acc v -> acc + "," + v)
            "[" + result + "]"

    [<JavaScript>]
    override this.Body =
        let env = WebScheme.Functions.builtins () |> ref

        let options =
            CodeMirror.EditorOptions(
                Height = "300px",
                StyleSheet = "css/schemecolors.css",
                ParserFile = [|"tokenizescheme.js"; "parsescheme.js"|],
                AutoMatchParens = true,
                DisableSpellcheck = true,
                LineNumbers = true,
                Path = "/CodeMirror/"
            )
        let text = TextArea[]
        let editor = ref None
        text |> OnAfterRender (fun n -> editor := Some (CodeMirror.create n.Dom options))

        let result = Div [Width "100%"; Attr.Class "output"]

        let appendResult (v : Scheme.SchemeValue) cls =
            let value = Div [ Span [Attr.Class (cls + " message")] -< [Text (toString v)]]
            result.Append(value)
            result.JQuery.ScrollTop(result.JQuery.Height()).Ignore

        let evaluate =
            Button [Text "Evaluate"]
            |>! OnClick (fun _ _ ->
                let text = CodeMirror.getCode editor.Value.Value
                try
                    let tokens = Lexer.getTokens text
                    let expressions = Parser.parseMain tokens
                    for e in expressions do
                        match Scheme.evaluate !env e  with
                        | Scheme.Null -> ()
                        | result -> appendResult result "success"
                with
                    e -> appendResult (Scheme.String (e.ToString())) "error"
                )

        let clear =
            Button [Text "Clear"]
            |>! OnClick (fun _ _ ->
                env := Functions.builtins()
                result.Clear()
            )
        Table [Width "100%"; Border "0.8"] -<
        [
            TR [Height "300px"] -< [  TD [ text ] ]
            TR [TD [evaluate; clear] ]
            TR [Height "200px"] -< [TD [result] ]
        ] :> _

