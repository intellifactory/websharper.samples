open System
open WebScheme
open WebScheme.Scheme

type Test = string * Scheme.SchemeValue list

let runTest ((source, values) : Test) = 
    printfn "================
%s
================" source
    let tokens = Lexer.getTokens source
    printfn "%A" tokens
    let p = Parser.parseMain tokens
    printfn "%A" p
     
    let env = Functions.builtins()
    let results = p |> List.map (Scheme.evaluate env)
    for result in results do
        match result with
        | Scheme.Null -> ()
        | _ -> printfn "%A" result


    let rec compareSchemeValue (x:Scheme.SchemeValue, y:Scheme.SchemeValue) =
        match (x,y) with
        | (Int x, Int y) -> x = y
        | (String x, String y) -> x = y
        | (Bool x, Bool y) -> x = y
        | (List x, List y) -> (x,y) ||> Seq.forall2 (fun o1 o2 -> compareSchemeValue(o1,o2) ) 
        | (Null, Null) -> true
        | (_, _) -> false


    if List.length values = List.length results && (values, results) ||> Seq.forall2 (fun o1 o2 -> compareSchemeValue(o1, o2))
    then ()
    else 
        printfn "Error in test"
        printfn "expected %A" values
        printfn "got %A" results
        Console.ReadKey() |> ignore

open Scheme

let tests = [
    "(define (f return)
(return 2)
3)
 
(f (lambda (x) x)) 
 
(callcc f)  ", [Null; Int 3; Int 2];

"(define (count-change amount)
(cc amount 5))

(define (cc amount kinds-of-coins)
(cond ((= amount 0) 1)
    ((or (< amount 0) (= kinds-of-coins 0)) 0)
    (else (+ (cc amount
                    (- kinds-of-coins 1))
                (cc (- amount
                    (first-denomination kinds-of-coins))
                    kinds-of-coins)))))

(define (first-denomination kinds-of-coins)
(cond ((= kinds-of-coins 1) 1)
    ((= kinds-of-coins 2) 5)
    ((= kinds-of-coins 3) 10)
    ((= kinds-of-coins 4) 25)
    ((= kinds-of-coins 5) 50)))

(count-change 100) ", [Null; Null; Null; Int 292];
"(define (fib n)
(cond ((= n 0) 0)
    ((= n 1) 1)
    (else (+ (fib (- n 1))
                (fib (- n 2))))))
(fib 5)
(fib 6)
(fib 7)", [Null; Int 5; Int 8; Int 13];

"(define (cons x y) 
 (define (dispatch n) 
   (
    cond 
     ((= n 0) x) 
     ((= n 1) y) 
     (else 'error)
   ))  
   dispatch
 )
(define (car x) (x 0))
(define (cdr x) (x 1))

(define x (cons 1 2))
(car x)
(cdr x) ", [Null; Null; Null; Null; Int 1; Int 2];

"(define (factorial n)
(if (= n 1)
    1
    (* n (factorial (- n 1)))))

    (factorial 5)", [Null; Int 120];

"(define (square x) (* x x))
(define (sum-of-squares x y)
(+ (square x) (square y)))
(define (f a)
(sum-of-squares (+ a 1) (* a 2)))
(f 5)    ", [Null; Null; Null; Int 136];

"(letrec ((fact
        (lambda (n)
        (if (= n 1)
            1
            (* n (fact (- n 1))))))
        )
(fact 5))   ",[Int 120];

"(letrec ((even?
        (lambda (n)
        (if (zero? n)
            #t
            (odd? (- n 1)))))
        (odd?
        (lambda (n)
        (if (zero? n)
            #f
            (even? (- n 1))))))
(even? 88))    ", [Bool true];

"(define gen-counter
(lambda ()
(let ((n 0))
    (lambda () (set! n (+ n 1)) n))))
      
    (define x (gen-counter))
    (x)
    (x)
      ", [Null; Null; Int 1; Int 2];

"(
letrec ((
counter 
    (
    lambda (n)
    (if (= 0 n) 'done (counter (- n 1)))
    )
))

(counter 20000)

)", [String "done"];

"(define (sum l)  (if (null? l) 0 (+ (car l) (sum (cdr l)))))
(sum '(1 2 3)) ", [Null; Int 6];

"(define (foldl f z xs) (if (null? xs)  z (foldl f (f z (car xs)) (cdr xs))))

(define (sum l) (foldl + 0 l))

(sum '(1 2 3))", [Null; Null; Int 6];

"(define (sum n)
    (define (impl n acc)
      (if (= n 0) acc
          (impl (- n 1) (+ acc n))))
    (impl n 0))
(sum 10000)", [Null; Int 50005000]
]


for t in tests do
    runTest t
