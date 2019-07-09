module Exercises

open FsCheck.Xunit

[<Property>]
let ``Binary adding works correctly`` () =
    let fst = [| true; false; true; true |]
    let snd = [| false; false; true; false |]
    let expected = [| true; false; false; false; true |]

    let result = Exercises.binaryAdd fst snd

    result |> SeqUtils.seqEqual expected