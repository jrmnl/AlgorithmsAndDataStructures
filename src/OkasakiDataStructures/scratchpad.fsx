#load "SinglyLinkedList.fs"

open OkasakiDataStructures

let randomInt =
    let rnd = System.Random()
    fun () -> rnd.Next(100)

let consRandom list =
    SinglyLinkedList.cons (randomInt()) list

let createFourElementsList() =
    let rnd = System.Random()
    SinglyLinkedList.empty
    |> consRandom
    |> consRandom
    |> consRandom
    |> consRandom

let firstList = createFourElementsList()
let secondList = createFourElementsList()

let head = SinglyLinkedList.head firstList
let tail = SinglyLinkedList.tail firstList

SinglyLinkedList.suffixes firstList

