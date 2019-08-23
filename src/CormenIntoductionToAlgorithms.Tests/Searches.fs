module Searches

open FsCheck.Xunit
open CormenIntoductionToAlgorithms.Searches

[<Property>]
let ``Linear search`` element (array:int[]) =
    let expected = array |> Array.tryFindIndex (fun x -> x = element)
    let result = LinearSearch.Find(array, element) |> Option.ofNullable
    expected = result

[<Property>]
let ``Binary search`` element (array:int[]) =
    let contains = array |> Array.contains element
    let sortedArray = array |> Array.sort

    let result = BinarySearch.Find(sortedArray, element) |> Option.ofNullable

    match contains, result with
    | true, Some index -> sortedArray.[index] = element
    | false, None -> true
    | _ -> false