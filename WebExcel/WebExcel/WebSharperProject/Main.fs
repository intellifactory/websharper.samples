namespace WebExcel

open System.Collections.Generic
open IntelliFactory.WebSharper

module Styles =
    [<Sealed>]
    type Table() =
        inherit Resources.BaseResource("Styles.css")

[<System.Web.UI.WebResource("Styles.css", "text/css")>]
do()

type EvalResult = Ok of obj | Error of string

module Ast =
    open System.Collections.Generic

    type Context = string -> EvalResult option

    type Expr =
        | Value of obj
        | Ref of string
        | Operation of (Context -> list<Expr>  -> EvalResult) * list<Expr>

    [<JavaScript>]
    let eval (ctx : Context) = function
        | Value o -> Ok o
        | Ref name ->
            match ctx name with
            | Some r -> r
            | None -> Error("Name " + name + " not found")
        | Operation (f, args) -> f ctx args

    [<JavaScript>]
    let bind ctx f e =
        match eval ctx e with
        | Ok v -> f v
        | e -> e

    [<JavaScript>]
    let bindList ctx f args =
        let rec impl l acc =
            match l with
            | [] -> f (List.rev acc)
            | x::xs -> x |> bind ctx (fun o -> impl xs (o::acc))
        impl args []

    [<JavaScript>]
    let getReferences e =
        let rec impl (acc : Set<_>) = function
            | Value _ -> acc
            | Ref v -> acc.Add (v)
            | Operation(_, l) -> (acc, l) ||> Seq.fold impl
        impl Set.empty e

module Operations =

    open Ast

    [<JavaScript>]
    let adapt f ctx args =
        try
            match args with
            | [e1; e2] ->
                e1 |> bind ctx (fun v1 ->
                    e2 |> bind ctx (fun v2 ->
                        Ok(f (unbox<double> v1) (unbox<double> v2))
                    )
                )
            | _ -> Error("Incorrect number of arguments")
        with
            e -> e.Message |> Error

    [<JavaScript>]
    let add = adapt (+)

    [<JavaScript>]
    let sub = adapt (-)

    [<JavaScript>]
    let mul = adapt (*)

    [<JavaScript>]
    let div = adapt (/)

    [<JavaScript>]
    let gt = adapt (>)

    [<JavaScript>]
    let ge = adapt (>=)

    [<JavaScript>]
    let lt = adapt (<)

    [<JavaScript>]
    let le = adapt (<=)

    [<JavaScript>]
    let eq = adapt (=)

    [<JavaScript>]
    let neq = adapt (<>)

    [<JavaScript>]
    let iif ctx args =
        try
            match args with
            | [c; ifTrue; ifFalse] ->
                c |> bind ctx (fun cond ->
                    if (unbox<bool> cond) then eval ctx ifTrue
                    else eval ctx ifFalse
                )
            | _ -> Error "Invalid number of arguments"
        with
            e -> Error e.Message

    [<JavaScript>]
    let average ctx args =
        try
            args |> bindList ctx (fun objs ->
                As<list<double>> objs
                |> List.average
                |> box
                |> Ok
            )
        with
            e -> Error e.Message

    [<JavaScript>]
    let stdev ctx args =
        try
            args |> bindList ctx (fun objs ->
                let vals = objs |> List.map (unbox<double>)
                let mean = List.average vals
                let len = float (List.length vals)
                let s =
                    vals
                    |> Seq.map (fun v -> (v - mean)**2.0)
                    |> Seq.sum
                Ok (box (sqrt (s / len)))
            )
        with
            e -> Error e.Message

    [<JavaScript>]
    let operations =
        let predefined =
            [
                "IF", iif
                "AVERAGE", average
                "STDEV", stdev
            ]
        let d = Dictionary()
        for (k, v) in predefined do
            d.[k] <- v
        d

    [<JavaScript>]
    let Get name =
        if operations.ContainsKey name
        then operations.[name]
        else failwith ("operation " + name + " not found")

    [<JavaScript>]
    let Add name operation =
        let wrapped (f: JavaScript.Function) ctx args =
            try
                args
                    |> bindList ctx (fun vals ->
                        Ok (f.Apply(null, Array.ofList vals)))
            with
                e -> Error e.Message
        operations.[name] <- wrapped operation

module Parser =

    open Ast
    open IntelliFactory.WebSharper.EcmaScript

    [<JavaScript>]
    let some v (rest : string) = Some(v, rest)

    [<JavaScript>]
    let capture pattern text =
        let regex = RegExp("^(" + pattern + ")(.*)")
        if regex.Test(text)
        then
            let v = regex.Exec(text)
            some v.[1] v.[2]
        else None

    [<JavaScript>]
    let matchValue pattern = (capture @"\s*") >> (Option.bind (snd >> capture pattern))

    [<JavaScript>]
    let matchSymbol pattern = (matchValue pattern) >> (Option.bind (snd >> Some))

    [<JavaScript>]
    let (|NUMBER|_|) = matchValue @"-?\d+\.?\d*"

    [<JavaScript>]
    let (|IDENTIFIER|_|) = matchValue @"[A-Za-z]\w*"

    [<JavaScript>]
    let (|LPAREN|_|) = matchSymbol @"\("

    [<JavaScript>]
    let (|RPAREN|_|) = matchSymbol @"\)"

    [<JavaScript>]
    let (|PLUS|_|) = matchSymbol @"\+"

    [<JavaScript>]
    let (|MINUS|_|) = matchSymbol @"-"

    [<JavaScript>]
    let (|GT|_|) = matchSymbol @">"

    [<JavaScript>]
    let (|GE|_|) = matchSymbol @">="

    [<JavaScript>]
    let (|LT|_|) = matchSymbol @"<"

    [<JavaScript>]
    let (|LE|_|) = matchSymbol @"<="

    [<JavaScript>]
    let (|EQ|_|) = matchSymbol @"="

    [<JavaScript>]
    let (|NEQ|_|) = matchSymbol @"<>"

    [<JavaScript>]
    let (|MUL|_|) = matchSymbol @"\*"

    [<JavaScript>]
    let (|DIV|_|) = matchSymbol @"/"

    [<JavaScript>]
    let (|COMMA|_|) = matchSymbol @","

    [<JavaScript>]
    let operation op args rest = some (Operation(op, args)) rest

    // error handling in cast of unknown operation is omitted
    let rec [<JavaScript>] (|Factor|_|) = function
        | IDENTIFIER(id, r) ->
            match r with
            | LPAREN (ArgList (args, RPAREN r)) -> operation (Operations.Get id) args r
            | _ -> some(Ref (id.ToUpper())) r
        | NUMBER (v, r) -> some (Value (System.Double.Parse v)) r
        | LPAREN(Logical (e, RPAREN r)) -> some e r
        | _ -> None

    and [<JavaScript>] (|ArgList|_|) = function
        | Logical(e, r) ->
            match r with
            | COMMA (ArgList(t, r1)) -> some (e::t) r1
            | _ -> some [e] r
        | rest -> some [] rest

    and [<JavaScript>] (|Term|_|) = function
        | Factor(e, r) ->
            match r with
            | MUL (Term(r, rest)) -> operation Operations.mul [e; r] rest
            | DIV (Term(r, rest)) -> operation Operations.div [e; r] rest
            | _ -> some e r
        | _ -> None

    and [<JavaScript>] (|Expr|_|) = function
        | Term(e, r) ->
            match r with
            | PLUS (Expr(r, rest)) -> operation Operations.add [e; r] rest
            | MINUS (Expr(r, rest)) -> operation Operations.sub [e; r] rest
            | _ -> some e r
        | _ -> None

    and [<JavaScript>] (|Logical|_|) = function
        | Expr(l, r) ->
            match r with
            | GE (Logical(r, rest)) -> operation Operations.ge [l; r] rest
            | GT (Logical(r, rest)) -> operation Operations.gt [l; r] rest
            | LE (Logical(r, rest)) -> operation Operations.le [l; r] rest
            | LT (Logical(r, rest)) -> operation Operations.lt [l; r] rest
            | EQ (Logical(r, rest)) -> operation Operations.eq [l; r] rest
            | NEQ (Logical(r, rest)) -> operation Operations.neq [l; r] rest
            | _ -> some l r
        | _ -> None

    and [<JavaScript>] (|Formula|_|) (s : string) =
        if s.StartsWith("=") then
            match s.Substring(1) with
            | Logical(l, t) when System.String.IsNullOrEmpty(t) -> Some l
            | _ -> None
        else None


module Model =

    open System
    open System.Collections.Generic

    [<JavaScript>]
    let private toString o = o.ToString()

    [<JavaScript>]
    let private concat lines =
        let delimiter = ", "
        if Seq.isEmpty lines
        then ""
        else lines |> Seq.reduce(fun a b -> a + delimiter + b)

    [<JavaScript>]
    let rows = [1..10] |> List.map toString

    [<JavaScript>]
    let private rowsSet = Set.ofSeq rows

    [<JavaScript>]
    let cols = [int 'A'..int 'F'] |> List.map Char.ConvertFromUtf32

    [<JavaScript>]
    let colSet = Set.ofSeq cols

    [<JavaScript>]
    let private isReference (s : string) =
        if System.String.IsNullOrEmpty s || s.Length < 2 then false
        else
            let col = Char.ConvertFromUtf32(int s.[0])
            let row = s.Substring(1)
            rowsSet.Contains row && colSet.Contains col

    type ICellDataStorage =
        abstract member GetValue : string -> EvalResult option
        abstract member SetValue : cell : string * value : EvalResult -> unit

    type CellDataStorage [<JavaScript>] () =
        let results = new System.Collections.Generic.Dictionary<string, EvalResult>()

        [<JavaScript>]
        let setValue cell value = results.[cell] <- value

//        [<JavaScript>]
//        member this.GetFilledData() = 
//            results
//                |> Seq.choose (fun kv ->
//                    match kv.Value with
//                    | Ok v -> Some {Cell = kv.Key; Value = string v} 
//                    | Error _ -> None 
//                    )
//                |> Seq.toArray

        [<JavaScript>]
        member this.SetCellValue(cell, value) =
            if System.String.IsNullOrEmpty value
            then
                this.DeleteValue(cell)
                true
            else
                let (v, ok) = try Ok (box (float value)), true with _ -> Error "Not a number", false
                setValue cell v
                ok

        [<JavaScript>]
        member this.DeleteValue(cell) =
            if results.ContainsKey cell then
                results.Remove cell |> ignore

        [<JavaScript>]
        member this.GetCellValue(cell) =
            if results.ContainsKey cell
            then results.[cell] |> Some
            else None

        interface ICellDataStorage with
            [<JavaScript>]
            member this.GetValue(cell) = this.GetCellValue(cell)
            [<JavaScript>]
            member this.SetValue(cell, value) = setValue cell value

    type TopoSort [<JavaScript>] () =
        let map = new System.Collections.Generic.Dictionary<string, Set<_>>()

        [<JavaScript>]
        member this.Insert(cell, parents) =
            for p in parents do
                let s = if map.ContainsKey(p) then map.[p] else Set.empty
                map.[p] <- s.Add cell
            try
                this.GetDependents(cell) |> ignore
            with
                e ->
                this.Delete(cell, parents)
                raise e

        [<JavaScript>]
        member this.Delete(cell, parents) =
            for p in parents do
                let s = map.[p]
                map.[p] <- s.Remove cell

        [<JavaScript>]
        member this.GetDependents(s) =
            let visited = ref Set.empty
            let rec impl ((order, cycles) as state) s =
                if Set.contains s cycles then failwith ("Cycle detected:" + (concat cycles))
                if Set.contains s !visited
                then state
                else
                    visited := Set.add s !visited
                    if map.ContainsKey s
                    then
                        let children = map.[s]
                        ((order, Set.add s cycles), children)
                            ||> Seq.fold impl
                            |> (fun (l, cycle) -> List.Cons(s, l), Set.remove s cycles)
                    else
                        s::order, cycles

            impl ([], Set.empty) s |> fst

    type CellFormulaStorage [<JavaScript>](dataStorage : ICellDataStorage) =
        let map = new System.Collections.Generic.Dictionary<string, Ast.Expr>()
        let toposort = new TopoSort()

        [<JavaScript>]
        let getValue cell =
            match dataStorage.GetValue cell with
            | None -> Some(Ok 0.0)
            | x -> x

        [<JavaScript>]
        member this.HasFormula(cell) = map.ContainsKey cell

        [<JavaScript>]
        member this.DeleteFormula(cell) =
            if map.ContainsKey cell then
                let oldExpr = map.[cell]
                let parents = Ast.getReferences oldExpr
                toposort.Delete(cell, parents)
                map.Remove(cell) |> ignore


        [<JavaScript>]
        member this.SetFormula(cell, text) =
            match text with
            | Parser.Formula(f) ->
                let invalidReferences =
                    Ast.getReferences f
                    |> Seq.filter (not << isReference)
                    |> Seq.toList
                if List.isEmpty invalidReferences
                then
                    let parents = Ast.getReferences f

                    try
                        toposort.Insert(cell, parents)
                        map.[cell] <- f

                        this.Evaluate(cell)
                    with
                        e -> dataStorage.SetValue(cell, Error(e.ToString()))
                             [cell]
                else
                    dataStorage.SetValue(cell, Error ("Formula contains invalid references: " + (concat invalidReferences)))
                    [cell]
            | _ ->
                dataStorage.SetValue(cell, Error ("Invalid formula text:" + text))
                [cell]


        [<JavaScript>]
        member this.Evaluate(cell) =
            let dependencies = toposort.GetDependents(cell)
            for d in dependencies do
                if map.ContainsKey(d) then
                    let e = map.[d]
                    let res = Ast.eval getValue e
                    dataStorage.SetValue (d, res)
            dependencies


open IntelliFactory.WebSharper.Html

[<Require(typeof<Styles.Table>)>]
module UI =

    open System
    open System.Collections.Generic
    open IntelliFactory.WebSharper.Formlet

    type Presenter [<JavaScript>] () =

        let dataStorage = new Model.CellDataStorage()
        let formulaStorage = new Model.CellFormulaStorage(dataStorage)

        let userInput = new Dictionary<_, _>()

        let map = new Dictionary<_, _>()

        [<Inline "eval($s)">]
        let eval (s : string) = X<_>

        [<JavaScript>]
        let onFocus (cell : Element) =
            cell.AddClass("editing")
            cell.Value <- if userInput.ContainsKey cell.Id then userInput.[cell.Id] else ""

        [<JavaScript>]
        let onBlur (cell : Element) =
            cell.RemoveClass("editing")
            userInput.[cell.Id] <- cell.Value
            formulaStorage.DeleteFormula(cell.Id)

            cell.RemoveClass("error")
            cell.RemoveClass("formula")
            try
                let dependencies =
                    if cell.Value.StartsWith("=")
                    then
                        formulaStorage.SetFormula(cell.Id, cell.Value)
                    else
                        let ok = dataStorage.SetCellValue(cell.Id, cell.Value)
                        if ok
                        then formulaStorage.Evaluate(cell.Id)
                        else [cell.Id]

                for dep in dependencies do
                    let el : Element = map.[dep]
                    match dataStorage.GetCellValue(el.Id) with
                    | Some (Ok v) ->
                        el.RemoveAttribute("title")
                        if formulaStorage.HasFormula el.Id then
                            el.AddClass("formula")
                            el.SetAttribute("title", userInput.[el.Id])
                        el.Value <- v.ToString()
                    | Some (Error msg) ->
                        el.SetAttribute("title", msg)
                        el.AddClass("error")
                        el.Value <- "#ERROR"
                    | None ->
                        el.RemoveAttribute("title")
                        el.Value <- ""
            with
                e -> JavaScript.Alert(e.ToString())

        [<JavaScript>]
        member this.CreateCell(name) =
            let cell =
                Input [Id name]
                |>! OnFocus(fun e -> onFocus e)
                |>! OnBlur(fun e -> onBlur e)
                |>! OnKeyPress(fun e key ->
                    if key.CharacterCode = 13 then onBlur e
                    )
            map.Add(name, cell)
            cell

        [<JavaScript>]
        member this.AddNewFunctionWizardButton(panel : Element) =
            let button = JQueryUI.Button.New "Add function"
            panel.Append button

            let showDialog () =

                let functionName =
                    Controls.Input ""
                    |> Validator.Is(fun s -> s.Length <> 0 && s.IndexOf(' ') = -1)
                        "Function name should be non empty string without spaces."
                    |> Enhance.WithValidationFrame
                    |> Enhance.WithValidationIcon
                    |> Enhance.WithTextLabel "Name:"

                let functionText =
                    Controls.TextArea ""
                    |> Validator.IsNotEmpty "Function code cannot be empty."
                    |> Formlet.ValidatingMap (fun x -> 
                        let v = eval ("(" + x + ")")
                        match JavaScript.TypeOf(v) with
                        | JavaScript.Kind.Function -> v
                        | _ -> failwith "Function expected"
                        )
                    |> Enhance.WithValidationFrame
                    |> Enhance.WithValidationIcon
                    |> Enhance.WithTextLabel "Code:"

                let rec dialog =

                    let config = JQueryUI.DialogConfiguration()
                    
                    config.Draggable <- true
                    config.Height <- 500
                    config.Modal <- true
                    config.Width <- 500
                    config.CloseOnEscape <- false
                    config.Title <- "Add new function"

                    JQueryUI.Dialog.New(Div [ wizardBody ], config)
                and wizardBody =
                    (Formlet.Yield (fun f x -> (f, x))
                    <*> functionName
                    <*> functionText)
                    |> Enhance.WithErrorSummary "Errors"
                    |> Enhance.WithCustomSubmitButton {
                        Enhance.FormButtonConfiguration.Default
                        with
                            Label = Some "OK"
                        }
                    |> Enhance.WithFormContainer
                    |> Formlet.Run (fun (name, code) ->
                        Operations.Add name code
                        dialog.Close()
                        dialog.Destroy()
                        )
                panel.Append dialog
                dialog.Open()
            button.OnClick(fun _ -> showDialog ())

    [<JavaScript>]
    let main () =

        let presenter = new Presenter()

        Table [
            let toolbar = Div [Attr.Class "toolbar"] -< [] 
            presenter.AddNewFunctionWizardButton toolbar
            yield TR [TD [ColSpan (string Model.colSet.Count)] -< [toolbar]]
            yield TR [
                yield TD [Attr.Class "specialCell firstColumn"]
                for col in Model.cols do yield TD [Attr.Class "specialCell"] -< [Text col]]
            for row in Model.rows do
                yield TR [
                    yield TD [Attr.Class "specialCell firstColumn"] -< [ Text row ]
                    for col in Model.cols do yield TD [presenter.CreateCell (col + row)]
                ]
        ]

type ExcelControl() =
    inherit Web.Control()

    [<JavaScript>]
    override this.Body = upcast UI.main ()