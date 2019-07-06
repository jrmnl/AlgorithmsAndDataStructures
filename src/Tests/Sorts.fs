module Sorts

open FsCheck.Xunit
open IntroductionToAlgorithmsByCormen


let private isSorted sorter seq  = 
    let expected = sorter seq
    expected |> SeqUtils.seqEqual seq

let private isAscSorted seq = seq |> isSorted Seq.sort

let private isDescSorted seq = seq |> isSorted Seq.sortDescending

[<Property>]
let ``Insertion sort works correctly (Ascending)`` (unsorted:int[]) =
    InsertionSort.sortAsc unsorted
    |> isAscSorted
    
[<Property>]
let ``Insertion sort works correctly (Descending)`` (unsorted:int[]) =
    InsertionSort.sortDesc unsorted
    |> isDescSorted
    
[<Property>]
let ``Selection sort works correctly (Ascending)`` (unsorted:int[]) =
    SelectionSort.sort unsorted
    |> isAscSorted

[<Property>]
let ``Bubble sort works correctly (Ascending)`` (unsorted:int[]) =
    BubbleSort.sort unsorted
    |> isAscSorted

[<Property>]
let ``Merge sort works correctly (Ascending)`` (unsorted:int[]) =
    MergeSort.sort unsorted
    |> isAscSorted

[<Property>]
let ``Merge sort functionally works correctly (Ascending)`` (unsorted:int list) =
    MergeSortFunctionally.sort unsorted
    |> isAscSorted