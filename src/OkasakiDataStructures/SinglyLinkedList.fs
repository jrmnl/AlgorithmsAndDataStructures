namespace OkasakiDataStructures

[<RequireQualifiedAccess>]
module SinglyLinkedList =
    open System;
    open System.Collections.Generic

    type 'T SinglyLinkedList = 
        | Empty
        | Cons of 'T * 'T SinglyLinkedList

    let empty = Empty

    let isEmpty list =
        match list with
        | Empty -> true
        | _ -> false 

    let cons head tail = Cons(head, tail)

    let head list =
        match list with
        | Empty -> raise <| InvalidOperationException("List is empty")
        | Cons(head, _) -> head

    let tail list =
        match list with
        | Empty -> raise <| InvalidOperationException("List is empty")
        | Cons(_, tail) -> tail

    let rec concat x y =
        match x with
        | Empty -> y
        | Cons(head, tail) -> Cons(head, concat tail y)

    let rec update index newElement list =
        match list, index with
        | Empty, _ -> raise <| KeyNotFoundException("Wrong index")
        | Cons(_, tail), 0 -> Cons(newElement, tail) 
        | Cons(head, tail), _ -> Cons(head, update (index - 1) newElement tail)

    let rec suffixes list =
        match list with
        | Empty -> Cons(Empty, empty)
        | Cons(_, tail) -> Cons(list, suffixes tail)