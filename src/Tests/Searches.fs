module Searches

open FsCheck.Xunit
open IntroductionToAlgorithmsByCormen

[<Property>]
let ``Linear search works correctly`` element (array:int[]) =
    let expected = array |> Array.tryFindIndex (fun x -> x = element)
    let result = array |> LinearSearch.tryFindIndex element
    expected = result