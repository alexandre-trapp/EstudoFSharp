// Learn more about F# at http://fsharp.org

open Tour
open Tour.Classes
open Tour.Functions
open Tour.Collections
open Tour.TuplesRecords
open AsyncExample.NetCompatibilityExamples

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    BasicFunctions.result1

    Lists.sumOfSquares

    Tuples.tuple1

    UnitsOfMeasure.sampleValue3

    vector1

    printf "tracker %i\n" tracker.Current

    let readFile = new ReadFile("ronaldos path \n")
    readFile.ReadLine()

    AsyncExample.fetchUrlAsync
    AsyncExample.sites

    MyButton().TestEvent("ronaldo")
    0 // return an integer exit code

