module Tour.TuplesRecords

// From https://docs.microsoft.com/en-us/dotnet/fsharp/tour
// Visit the link above for more information on each topic
// You can also find more learning resources at https://fsharp.org/

module Tuples =

    /// A simple tuple of integers.
    let tuple1 = (1, 2, 3)

    /// A function that swaps the order of two values in a tuple.
    ///
    /// F# Type Inference will automatically generalize the function to have a generic type,
    /// meaning that it will work with any type.
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// A tuple consisting of an integer, a string,
    /// and a double-precision floating point number.
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2


module RecordTypes =

    /// This example shows how to define a new record type.
    type ContactCard = 
        { Name     : string
          Phone    : string
          Verified : bool }

    /// This example shows how to instantiate a record type.
    let contact1 = 
        { Name = "Alexandre"
          Phone = "(47)9669-6969"
          Verified = false }

    /// You can also do this on the same line with ';' separators.
    let contactOnSameLine = { Name = "Alexandre"; Phone = "(47) 9669-6969"; Verified = false }

    /// This example shows how to use "copy-and-update" on record values. It creates
    /// a new record value that is a copy of contact1, but has different values for
    /// the 'Phone' and 'Verified' fields.
    ///
    /// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 = 
        { contact1 with
            Phone = "(47)6969-1111"
            Verified = true }

    /// This example shows how to write a function that processes a record value.
    /// It converts a 'ContactCard' object to a string.
    let showContactCard (c: ContactCard) = 
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alexandre's Contact Card: %s" (showContactCard contact1)

    /// This is an example of a Record with a member.
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// Members can implement object-oriented members.
        member this.PrintedContactCard = 
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate = 
        { Name = "Trapp"
          Phone = "(47)1234-5678"
          Verified = false
          Address = "123 rua alfeneiros" }

    // Members are accessed via the '.' operator on an instantiated type.
    printfn "Trapp's alternate contact card is %s" contactAlternate.PrintedContactCard
