module Tests.Sorts

open FsCheck.Xunit
open IntroductionToAlgorithmsByCormen

let private sameSeq seq1 seq2 =
    let compare = Seq.compareWith Operators.compare
    compare seq1 seq2 = 0

let private isSorted sorter array  = 
    let expected = sorter array
    expected |> sameSeq array

let private isAscSorted = isSorted Seq.sort

let private isDescSorted = isSorted Seq.sortDescending

[<Property>]
let ``Insertion sort works correctly (Ascending)`` (unsorted:int[]) =
    InsertionSort.sortAsc unsorted
    |> isAscSorted
    
[<Property>]
let ``Insertion sort works correctly (Descending)`` (unsorted:int[]) =
    InsertionSort.sortDesc unsorted
    |> isDescSorted