module Tour.Functions

module BasicFunctions = 

    let multipleSum3 x = x*x + 3
    
    let result1 = multipleSum3 2 // deve retornar 2 * 2 + 3 = 7
    printfn "o resultado de 2*2 + 3 é: %d" result1

    let calcWithParameter(x:int) = 2*x*x - x/5 + 3
    
    let result2 = calcWithParameter(2 + 5)
    printf "o resultado de 2 + 3  = 5 => 2*5*5 - 5/5 + 3 é: %d" result2 // deve retornar 52

    // funções com condicionais 
    let functionsConditions x = 
        
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = functionsConditions(12.5)
    printfn "o resultado da função com condicionais é: %f" result3 // deve retornar 313.000000
    
module Immutability = 

    let number = 2 // não mutavel (number <- number + 1 causa erro)
                   
    let mutable mutableNumber = 2
    printfn "'mutableNumber' is %d" mutableNumber

    // When mutating a value, use '<-' to assign a new value.
    //
    // Note that '=' is not the same as this.  '=' is used to test equality.
    mutableNumber <- mutableNumber + 1
    printfn "'mutableNumber' changed to be %d" mutableNumber

module PipelinesAndComposition =
    
    let square x = x * x
    
    let addOne x = x + 1

    let isMod x = x % 2 <> 0
    
    let fiveNumbersList = [1;2;3;4;5]

    /// Given a list of integers, it filters out the even numbers,
    /// squares the resulting odds, and adds 1 to the squared odds.
    let squareModValuesAndAddOne values =
        
        let mods = List.filter isMod values
        let squares = List.map square values
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" fiveNumbersList (squareModValuesAndAddOne fiveNumbersList)

    /// A shorter way to write 'squareOddValuesAndAddOne' is to nest each
    /// sub-result into the function calls themselves.
    ///
    /// This makes the function much shorter, but it's difficult to see the
    /// order in which the data is processed.
    let squareOddValuesAndAddOneNested values = 
        List.map addOne (List.map square (List.filter isMod values))

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" fiveNumbersList (squareOddValuesAndAddOneNested fiveNumbersList)

    /// A preferred way to write 'squareOddValuesAndAddOne' is to use F# pipe operators.
    /// This allows you to avoid creating intermediate results, but is much more readable
    /// than nesting function calls like 'squareOddValuesAndAddOneNested'
    let squareOddValuesAndAddOnePipeline values = 
        values 
        |> List.filter isMod
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" fiveNumbersList (squareOddValuesAndAddOnePipeline fiveNumbersList)

    /// You can shorten 'squareOddValuesAndAddOnePipeline' by moving the second `List.map` call
    /// into the first, using a Lambda Function.
    ///
    /// Note that pipelines are also being used inside the lambda function.  F# pipe operators
    /// can be used for single values as well.  This makes them very powerful for processing data.
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isMod
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" fiveNumbersList (squareOddValuesAndAddOneShorterPipeline fiveNumbersList)

module RecursiveFunctions =

    /// This example shows a recursive function that computes the factorial of an
    /// integer. It uses 'let rec' to define a recursive function.module RecursiveFunctions =

    /// This example shows a recursive function that computes the factorial of an
    /// integer. It uses 'let rec' to define a recursive function.

    let rec factorial n =
        printfn "n = %d" n
        if n = 0 then 1 else n * factorial(n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)