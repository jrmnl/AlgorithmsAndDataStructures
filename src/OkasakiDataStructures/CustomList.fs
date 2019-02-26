namespace OkasakiDataStructures

type 'T CustomList =
    | Empty
    | Cons of 'T * 'T CustomList

module CustomList =

    let empty = Empty

    let isEmpty list =
        match list with
        | Empty -> true
        | _ -> false 

    let cons head tail = Cons(head, tail)

    let head list =
        match list with
        | Empty -> failwith "List is empty"
        | Cons(head, _) -> head

    let tail list =
        match list with
        | Empty -> failwith "List is empty"
        | Cons(_, tail) -> tail
    
    // O(n)
    let rec (++) x y =
        match x with
        | Empty -> y
        | Cons(head, tail) -> Cons(head, tail ++ y)

    // O(n)
    let rec update index newElement list =
        match list, index with
        | Empty, _ -> failwith "List is empty"
        | Cons(_, tail), 0 -> Cons(newElement, tail) 
        | Cons(_, tail), _ -> update (index - 1) newElement tail