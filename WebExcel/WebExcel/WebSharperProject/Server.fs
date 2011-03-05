namespace WebExcel

open IntelliFactory.WebSharper

type CellValue = 
    {
        mutable Cell : string
        mutable Value : string
    }
    
type Worksheet = 
    {
        mutable Width : int
        mutable Height : int
        mutable Cells : CellValue []
    }


module Server = 

    let private save, load = 
        let savedWorksheet : option<Worksheet> ref = ref None 
        let save ws = 
            lock savedWorksheet <| fun () -> 
                savedWorksheet := Some ws 
        let load () =
            lock savedWorksheet <| fun () -> !savedWorksheet
        save, load
                
    let Get = load

    [<Rpc>]
    let Save width height cells = 
        save <|
            {
                Width = width
                Height = height
                Cells = cells
            }

