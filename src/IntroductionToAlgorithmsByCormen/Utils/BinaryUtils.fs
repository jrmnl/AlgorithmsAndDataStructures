module BinaryUtils

open System

let add3 fst snd thd =
    let toInt (x:bool) = Convert.ToInt32(x)
    match toInt fst + toInt snd + toInt thd with
    | 3 -> true, true
    | 2 -> false, true 
    | 1 -> true, false 
    | 0 -> false, false
    | _ -> failwith "fatal"