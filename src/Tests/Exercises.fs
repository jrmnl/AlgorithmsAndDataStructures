module Exercises

open FsCheck.Xunit
open IntroductionToAlgorithmsByCormen

[<Property>]
let ``Binary adding works correctly`` () =
    let fst = [| true; false; true; true |]
    let snd = [| false; false; true; false |]
    let expected = [| true; false; false; false; true |]

    let result = Exercises.binaryAdd fst snd

    result |> SeqUtils.seqEqual expected

[<Property>]
let ``Contains sum in positive scenario`` () =
    [| 15; 4344; 654; 767; 4545 |]
    |> Exercises.findContainsSum (654 + 4545)

[<Property>]
let ``Contains sum in negative scenario`` () =
    [| 15; 4344; 654; 767; 4545 |]
    |> Exercises.findContainsSum (16 + 767)
    |> not

[<Property>]
let ``Contains sum not calculates first element twice`` () =
    [| 50; 0 |]
    |> Exercises.findContainsSum 100
    |> not

[<Property>]
let ``Contains sum on empty array`` () =
    Array.empty
    |> Exercises.findContainsSum (123)
    |> not