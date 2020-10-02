module AsyncExample

    // F# has built-in features to help with async code
    // without encountering the "pyramid of doom"
    //
    // The following example downloads a set of web pages in parallel.

    open System.Net
    open System
    open System.IO
    open Microsoft.FSharp.Control.CommonExtensions

    // Fetch the contents of a URL asynchronously
    let fetchUrlAsync url =
        async { // "async" keyword and curly braces
                // creates an "async" object
        
            let req = WebRequest.Create(Uri(url))
            use! resp = req.AsyncGetResponse()
                // use! is async assignment
            
            use stream = resp.GetResponseStream()
                // "use" triggers automatic close()
                // on resource at end of scope

            use reader = new IO.StreamReader(stream)
            let html = reader.ReadToEnd()

            printfn "finished downloading %s" url 
        }

    // a list of sites to fetch
    let sites = ["http://www.bing.com";
                 "http://www.google.com";
                 "http://www.microsoft.com";
                 "http://www.amazon.com";
                 "http://www.yahoo.com"]
        
    // do it
    sites
    |> List.map fetchUrlAsync   // make a list of async tasks
    |> Async.Parallel           // set up the tasks to run in parallel
    |> Async.RunSynchronously   // start them off

    module NetCompatibilityExamples =

        type MyButton() =
            let clickEvent = new Event<_>()

            [<CLIEvent>]
            member this.OnClick = clickEvent.Publish

            member this.TestEvent(arg) =
                clickEvent.Trigger(this, arg)

        // test
        let myButton = new MyButton()
        myButton.OnClick.Add(fun (sender, arg) ->
                printfn "Click event with arg=%O" arg)

        myButton.TestEvent("Hello World!")