module Searches

open FsCheck.Xunit
open IntroductionToAlgorithmsByCormen

[<Property>]
let ``Linear search works correctly`` element (array:int[]) =
    let expected = array |> Array.tryFindIndex (fun x -> x = element)
    let result = array |> LinearSearch.tryFindIndex element
    expected = result

[<Property>]
let ``Binary search works correctly`` element (array:int[]) =
    let contains = array |> Array.contains element
    let sortedArray = array |> Array.sort

    let result = sortedArray |> BinarySearch.tryFindIndex element

    match contains, result with
    | true, Some index -> sortedArray.[index] = element
    | false, None -> true
    | _ -> false