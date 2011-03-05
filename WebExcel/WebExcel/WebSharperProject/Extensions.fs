namespace WebExcel

[<AutoOpen>]
module Extensions =
    open IntelliFactory.Formlet.Base
    open IntelliFactory.WebSharper
    open IntelliFactory.WebSharper.Formlet

    module Formlet =

        [<JavaScript>]
        let ValidatingMap (f: 'T1 -> 'T2) (form: Formlet<'T1>) =
            form
            |> Formlet.MapResult (function
                | Success r ->
                    try Success (f r) with e -> Failure [e.Message]
                | Failure f ->
                    Failure f)
