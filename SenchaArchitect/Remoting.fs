namespace Website

open IntelliFactory.WebSharper

type Person =
    {
        Name : string 
        Age  : int
    }

module Remoting =

    [<Remote>]
    let GetAttending() =
        async {
            do! Async.Sleep 1000
            failwith "oops"
            return [|
                {
                    Name = "Leroy Mitchell"
                    Age  = 31
                }        
                {        
                    Name = "Evelyn Hill"
                    Age  = 58
                }        
                {        
                    Name = "Claude Nelson"
                    Age  = 66
                }        
                {        
                    Name = "Lydia Hernandez"
                    Age  = 13
                }        
                {        
                    Name = "Mae Ward"
                    Age  = 94
                }            
            |]
        }

    [<Remote>]
    let Save (data: Person[]) =
        async {
            return data.Length    
        }