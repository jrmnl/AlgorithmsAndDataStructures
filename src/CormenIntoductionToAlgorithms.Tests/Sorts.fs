module Sorts

open FsCheck.Xunit
open CormenIntoductionToAlgorithms.Sorts

let private isSorted (array:int[]) =
    let rec loop current =
        let next = current + 1
        if next >= array.Length
        then true
        elif array.[current] <= array.[next]
        then loop next
        else false
    loop 0

[<Property>]
let ``Insertion sort`` array =
    InsertionSort.Sort array
    isSorted array
    
[<Property>]
let ``Selection sort`` array =
    SelectionSort.Sort array
    isSorted array

[<Property>]
let ``Bubble sort`` array =
    BubbleSort.Sort array
    isSorted array

[<Property>]
let ``Merge sort`` array =
    MergeSort.Sort array
    isSorted array

[<Property>]
let ``Heap sort`` array =
    HeapSort.Sort array
    isSorted array