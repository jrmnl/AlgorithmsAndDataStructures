namespace DataStructures

module CustomList =
    type 'T List =
        | Empty
        | Cons of 'T * 'T List

    let empty() = Empty

    let isEmpty list =
        match list with
        | Empty -> true
        | _ -> false 

    let cons x s = Cons(x s)

    let head list =
        match list with
        | Empty -> failwith "List is empty"
        | Cons(x, _) -> x

    let tail list =
        match list with
        | Empty -> failwith "List is empty"
        | Cons(_, s) -> s

    let rec (++) x y =
        match x with
        | Empty -> y
        | _ -> Cons(head x, (tail x) ++ y)