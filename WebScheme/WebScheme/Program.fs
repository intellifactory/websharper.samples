namespace WebScheme

open System
open IntelliFactory.WebSharper

type Token = 
    | Identifier of string
    | Quote      of Token
    | Number     of int
    | Boolean    of bool
    | String     of string
    | List       of Token list

module Lexer = 
    [<JavaScript>] 
    let private toString (chars : char list) = 
        chars |> List.fold (fun acc s -> string s + acc) ""

    [<JavaScript>] 
    let isDigit c = c >= '0' && c <= '9' 
    [<JavaScript>] 
    let isWhiteSpace c = c = ' ' || c = '\t' || c = '\r' || c = '\n'

    [<JavaScript>] 
    let getTokens (source : string) = 
        let rec getToken inList = function
            | [] -> 
                if inList 
                then failwith "syntax error (missing close bracket)" 
                else None, []
            | ')'::rest -> 
                if inList 
                then None, rest 
                else failwith "syntax error (missing open bracket)" 
            | '('::rest ->
                let l, rest = getList true rest
                Some (List l), rest
            | '\''::rest ->
                let t, rest = getToken inList rest
                match t with
                | Some t -> Some (Quote t), rest
                | None -> failwith "syntax error (invalid quotation)"
            | c::rest when isWhiteSpace c -> getToken inList rest
            | '-'::((c::_) as rest) when isDigit c ->
                let num, rest = getNumber rest
                Some (Number -num), rest
            | (c::_) as rest when isDigit c ->
                let num, rest = getNumber rest
                Some (Number num), rest
            | '#'::'t'::rest ->
                Some (Boolean true), rest                
            | '#'::'f'::rest ->
                Some (Boolean false), rest                
            | '"'::rest ->
                let s, rest = getString rest
                Some (String s), rest
            | rest ->
                let identifier, rest = getIdentifier rest
                Some (Identifier identifier), rest
        
        and getList counter l = 
            let rec impl acc (rest : char list) l = 
                match getToken counter l with
                | Some t, rest -> impl (t::acc) [] rest
                | None, rest -> List.rev acc, rest
            impl [] [] l
        
        and getNumber l = 
            let rec impl acc = function
                | c::rest when isDigit c ->
                    let value = int c - int '0'
                    impl (acc * 10 + value) rest
                | rest -> acc, rest
            impl 0 l
        
        and getString l = 
            let rec impl acc = function
                | [] -> failwith "syntax error (malformed string)"
                | '\\'::'"'::rest -> impl ('"'::acc) rest
                | '"'::rest -> (toString acc, rest)
                | x::rest -> impl (x::acc) rest
            impl [] l

        and getIdentifier l = 
            let rec impl acc = function
                | [] -> toString acc, []
                | (('('::_) as rest)
                | ((')'::_) as rest) -> toString acc, rest
                | c::rest when isWhiteSpace c -> toString acc, rest
                | c::rest -> impl (c::acc) rest
            impl [] l
        
        let rec impl l = 
            [
                match getToken false l with
                | Some t, r -> 
                    yield t
                    match r with
                    | [] -> ()
                    | rest -> yield! impl rest
                | None, _ -> ()
            ]
        source 
            |> fun s -> s.ToCharArray()
            |> List.ofSeq
            |> impl


type Expr = 
    | Bool      of bool
    | Number    of int
    | String    of string
    | Atom      of string
    | List      of Expr list
    | Var       of string
    | Apply     of Expr * Expr list
    | Lambda    of string list * Expr
    | If        of Expr * Expr * Expr option
    | Assign    of string * Expr
    | Cond      of (Expr * Expr) list * Expr option
    | Let       of (string * Expr) list * Expr
    | LetRec    of (string * Expr) list * Expr
    | Sequence  of Expr list
    | CallCC    of Expr

module Parser = 
    let rec [<JavaScript>] private parse tokens = 
        match tokens with
        | Token.Identifier s -> Expr.Var s
        | Token.Number n -> Expr.Number n
        | Token.Boolean b -> Expr.Bool b 
        | Token.String s -> Expr.String s
        | Token.Quote t -> parseQuote t
        | Token.List(tokens) -> parseList tokens

    and [<JavaScript>] private parseQuote = function
        | Token.Number n -> Expr.Number n
        | Token.Boolean b -> Expr.Bool b
        | Token.String s -> Expr.String s
        | Token.Quote _ -> failwith "quoted quotes not supported"
        | Token.Identifier id -> Expr.Atom id
        | Token.List l -> l |> List.map parseQuote |> Expr.List
    
    and [<JavaScript>] private parseCond tokens = 
        let rec impl acc = function
            | [] -> List.rev acc, None 
            | [Token.List([Token.Identifier "else"; body])] -> List.rev acc, Some(parse body)
            | Token.List([cond; body])::rest -> 
                let cond = parse cond
                let body = parse body
                impl ((cond, body)::acc) rest
            | _ -> failwith "invalid 'cond' syntax"
        impl [] tokens
    
    and [<JavaScript>] private parseList = function
        | Token.Identifier "begin"::rest -> 
            rest 
            |> List.map parse 
            |> Sequence        
        | Token.Identifier "cond"::body -> 
            parseCond body 
            |> Expr.Cond
        | [Token.Identifier "callcc"; body] ->
            parse body
            |> Expr.CallCC
        | Token.Identifier "lambda"::Token.List(formals)::body -> 
            let formals = parseFormals formals
            Lambda(formals, Sequence(parseMain body))
        | Token.Identifier "let"::Token.List(bindings)::body -> 
            parseLet bindings body Let
        | Token.Identifier "letrec"::Token.List(bindings)::body -> 
            parseLet bindings body LetRec
        | [Token.Identifier "if"; cond; ifTrue] -> 
            let cond = parse cond
            let ifTrue = parse ifTrue
            Expr.If(cond, ifTrue, None)
        | [Token.Identifier "if"; cond; ifTrue; ifFalse] ->
            let cond = parse cond
            let ifTrue = parse ifTrue
            let ifFalse = parse ifFalse
            Expr.If(cond, ifTrue, Some ifFalse)        
        | [Token.Identifier "set!"; Token.Identifier(var); value] -> 
            Expr.Assign(var, parse value)
        | proc::args -> 
            Expr.Apply(parse proc, List.map parse args)
        | x -> 
            failwith "unrecognized token sequence"
    and [<JavaScript>] private parseFormals formals = 
        formals 
            |> List.map parse 
            |> List.map(function 
                | Expr.Var s -> s 
                | _ -> failwith "formal parameter should be var"
                )
    and [<JavaScript>] private parseLet bindings body f =
        let bindings = 
            bindings
            |> List.map(function 
                | Token.List([Token.Identifier name; value]) -> name, parse value 
                | _ -> failwith "invalid binding structure"
                )
        let body = parseMain body
        f(bindings, Sequence body)
     
    and [<JavaScript>] parseMain tokens = 
        [
            match tokens with
            | Token.List([Token.Identifier "define"; Token.Identifier var; body])::xs ->
                yield Assign(var, parse body)
                yield! parseMain xs
            | Token.List(Token.Identifier "define"::Token.List(Token.Identifier var::formals)::body)::xs ->
                yield Assign(var ,Lambda(parseFormals formals, Sequence(parseMain body)))
                yield! parseMain xs
            | x::xs -> 
                yield parse x
                yield! parseMain xs
            | [] -> ()
        ]

module Scheme = 

    open System.Collections.Generic

    type SchemeValue = 
        | Int of int 
        | String of string 
        | Bool of bool 
        | Function of (SchemeValue list -> Cont -> Step)
        | List of SchemeValue list
        | Null

    and Step = Step of (unit -> Step) option
    and Cont = SchemeValue -> Step
    

    type EnvFrame = Dictionary<string, SchemeValue>
    type Env = EnvFrame list

    [<JavaScript>]
    let private tryFindFrame name (d : EnvFrame) =
        if d.ContainsKey name 
        then Some (d, d.[name])
        else None
    
    [<JavaScript>]
    let makeEnv prevEnv content  =
        let d = new Dictionary<_, _>()
        for (name, value) in content do
            d.Add(name, value)
        d::prevEnv 

    [<JavaScript>]
    let private get name (env : Env) = 
        match List.tryPick (tryFindFrame name) env with
        | Some(_, value) -> value
        | None -> failwith ("name '" + name + "' not found")

    [<JavaScript>]
    let private set name value (env : Env) = 
        match List.tryPick (tryFindFrame name) env with
        | Some (frame, _) -> frame.[name] <- value
        | None ->
            match env with
            | h::_ -> 
                h.[name] <- value
            | [] -> failwith "empty env."
    
    [<JavaScript>]    
    let delay f = f |> Some |> Step
    
    type ContBuilder [<JavaScript>]() = 

        [<JavaScript>]
        member inline this.Return (v) = fun (k : Cont) -> delay (fun() -> k v)

        [<JavaScript>]
        member inline this.ReturnFrom (v : Cont -> Step) = v
        
        [<JavaScript>]
        member inline this.Bind(c : Cont -> Step, f : SchemeValue -> Cont -> Step) : Cont -> Step = 
            fun (rk : Cont) ->
                let c1 (v : SchemeValue) = 
                    let c2 = f v
                    delay (fun() -> c2 rk)
                delay(fun() -> c c1)

    [<JavaScript>]
    let K = ContBuilder()

    [<JavaScript>]
    let private callCC (Function f) : Cont -> Step =
        fun (extK : Cont) ->
            let exit = Function (fun [arg] _ -> K.Return arg extK)
            f [exit] extK
    
    [<JavaScript>]
    let rec private evaluateExpression expr (env : Env) = 
        match expr with
            | Expr.List(values) -> 
                let rec impl acc l = 
                    match l with
                    | [] ->  K { return List (List.rev acc) }
                    | v::rest -> K { 
                        let! res = evaluateExpression v env
                        return! impl (res::acc) rest 
                        }
                impl [] values
            | Expr.Atom atom -> 
                K { return String atom }
            | Expr.Bool v -> 
                K { return Bool v }
            | Expr.Number n -> 
                K { return Int n }
            | Expr.String s -> 
                K { return String s }
            | Expr.CallCC proc ->
                K { 
                    let! func = evaluateExpression proc env
                    match func with
                    | Function _  -> return! callCC func
                    | x -> return! failwith "callCC argument should be function"
                }
            | Expr.Assign (name, v) -> 
                K {
                    let! value = evaluateExpression v env
                    set name value env
                    return Null
                }
            | Expr.Cond (clauses, elseCase) ->
                let rec evalCond = function
                    | (cond, body)::xs, _ -> 
                        K { 
                            let! v = evaluateExpression cond env
                            let (Bool v) = v
                            if v 
                            then return! evaluateExpression body env
                            else return! evalCond(xs, elseCase)
                        }
                    | [], Some(c) -> K { return! evaluateExpression c env}
                    | _ -> K { return Null }
                K { return! evalCond (clauses, elseCase)}
            | Expr.Apply(f, args) ->
                K { 
                    let! value = evaluateExpression f env
                    match value with
                    | Function f ->
                        let rec evalArgs acc = function
                            | [] -> K { return! f (List.rev acc) }
                            | x::xs ->  K { 
                                let! value = evaluateExpression x env
                                return! evalArgs (value::acc) xs
                                }
                        return! evalArgs [] args
                    | _ -> return! failwith "function expected"    
                }
            | Expr.If (cond, ifTrue, ifFalse) ->
                K { 
                    let! v = evaluateExpression cond env
                    let (Bool v) = v
                    if v
                    then return! evaluateExpression ifTrue env
                    else 
                        match ifFalse with
                        | Some f -> return! evaluateExpression f env
                        | None -> return Null
                }
            | Expr.Lambda(formals, body) ->
                let apply args= 
                    let newEnv = 
                        List.zip formals args
                        |> makeEnv env
                    K { return! evaluateExpression body newEnv}
                K { return Function apply }
            | Expr.Let(bindings, body) ->
                let rec evalBindings acc = function 
                    | [] -> 
                        let newEnv = 
                            acc 
                            |> List.rev
                            |> makeEnv env
                        K { return! evaluateExpression body newEnv }
                    | (name, x)::xs -> K { 
                        let! v = evaluateExpression x env
                        return! evalBindings ((name, v)::acc) xs
                        }
                K { return! evalBindings [] bindings }
            | Expr.LetRec(bindings, body) ->
                let newEnv = 
                    bindings
                    |> List.map (fun (name, _) -> name, Null)
                    |> makeEnv env
                let rec evalBindings acc = function 
                    | [] -> K { return! evaluateExpression body newEnv }
                    | (n, x)::xs -> K { 
                        let! v = evaluateExpression x newEnv
                        set n v newEnv
                        return! evalBindings (v::acc) xs
                        }
                K { return! evalBindings [] bindings }
            | Expr.Sequence(statements) ->
                let rec impl s = 
                    match s with
                    | [] -> K { return Null } 
                    | [x] -> K { return! evaluateExpression x env }
                    | x::xs -> K { 
                        let! _ = evaluateExpression x env
                        return! impl xs
                        }
                K { return! impl statements } 
            | Expr.Var(name) ->
                K { return get name env }
    
    [<JavaScript>]
    let evaluate env expr = 
        let result = ref Null
        let ok = ref true
        let finalCont = fun o -> result := o; Step None
    
        let step = ref (evaluateExpression expr env finalCont)
        
        while !ok do
            let (Step s) = !step
            match s with
            | Some f ->
                step := f()
            | None ->
                ok := false
        !result

module Functions = 
    
    open Scheme
    
    [<JavaScript>]
    let makeNumeric op = 
        fun args -> K { 
            return args |>  Seq.reduce (fun (Int acc) (Int v) -> Int(op acc v)) 
        } |> Function

    [<JavaScript>]
    let makeBool op = 
        fun args -> K { 
            return args |>  Seq.reduce (fun (Bool acc) (Bool v) -> Bool(op acc v)) 
        } |> Function


    [<JavaScript>]
    let builtins () = 
        [ 
          "+", makeNumeric (+)
          "-", makeNumeric (-)
          "*", makeNumeric (*)
          "/", makeNumeric (/)
          "or", makeBool (||)
          "<",  (fun [Int a; Int b] -> K { return Bool(a < b)}) |> Function
          "=", (function 
                    | [] | [_]-> failwith "invalid args"
                    | [Int x; Int y] -> K { return Bool (x = y) }
                    | [Bool x; Bool y] -> K { return Bool (x = y) }
                    | [Int x; Int y; Int z] -> K { return Bool (x = y && y = z) } 
                    | [Bool x; Bool y; Bool z] -> K { return Bool (x = y && y = z) } 
                    | _ -> failwith "not supported")
               |> Function
          "zero?", (fun [Int x] -> K { return Bool(x = 0)} ) |> Function
          "null?", (function
                    | [List []] -> K { return Bool true}
                    | _  -> K { return Bool false} ) |> Function
          "car", (fun [List (x::_)] -> K { return x } ) |> Function
          "cdr", (fun [List (_::xs)] -> K { return List xs } ) |> Function
        ] 
        |> Scheme.makeEnv []