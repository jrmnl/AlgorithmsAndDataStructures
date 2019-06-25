module Tests.Sorts

open FsCheck.Xunit
open IntroductionToAlgorithmsByCormen

let private sameSeq seq1 seq2 =
    let compare = Seq.compareWith Operators.compare
    compare seq1 seq2 = 0

let private isSorted sorted =
    let expected = Seq.sort sorted
    expected |> sameSeq sorted

[<Property>]
let ``Insertion sort works correctly`` (unsorted:int[]) =
    InsertionSort.sort unsorted
    |> isSorted