module Sorts

open FsCheck.Xunit
open IntroductionToAlgorithmsByCormen


let private isSorted sorter array  = 
    let expected = sorter array
    expected |> SeqUtils.seqEqual array

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