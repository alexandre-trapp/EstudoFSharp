﻿// Learn more about F# at http://fsharp.org

open Tour.Functions
open Tour.Collections
open Tour.TuplesRecords
open Tour

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    BasicFunctions.result1

    Lists.sumOfSquares

    Tuples.tuple1

    UnitsOfMeasure.sampleValue3

    0 // return an integer exit code

