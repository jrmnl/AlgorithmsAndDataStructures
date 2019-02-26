#load "CustomList.fs"

open OkasakiDataStructures.CustomList

let randomInt =
    let rnd = System.Random()
    fun () -> rnd.Next()

let consRandom list =
    cons (randomInt()) list

let createFourElementsList() =
    let rnd = System.Random()
    empty
    |> consRandom
    |> consRandom
    |> consRandom
    |> consRandom

let firstList = createFourElementsList()
let secondList = createFourElementsList()

let head = head firstList
let tail = tail firstList

let concated = firstList ++ secondList
concated