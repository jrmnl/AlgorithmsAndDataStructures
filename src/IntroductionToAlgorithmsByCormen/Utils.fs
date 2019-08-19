namespace IntroductionToAlgorithmsByCormen

open System

[<RequireQualifiedAccess>]
module BinaryUtils =

    let add3 fst snd thd =
        let toInt (x:bool) = Convert.ToInt32(x)
        match toInt fst + toInt snd + toInt thd with
        | 3 -> true, true
        | 2 -> false, true 
        | 1 -> true, false 
        | 0 -> false, false
        | _ -> failwith "fatal"

module TupleUtils =
    let thd (_,_,c) = c
    
[<RequireQualifiedAccess>]
module Random =
    let permuteBySorting (array:'a[]) =
        let rnd = Random()

        array
        |> Seq.map (fun x -> rnd.Next(0, pown array.Length 3), x)
        |> Seq.sortBy fst
        |> Seq.map snd
        |> Seq.toArray
        
    let permuteInPlace (array:'a[]) =
        let rnd = Random()
        
        let newArr = Array.copy array
        for i = 0 to newArr.Length - 1 do
            let rndIndex = rnd.Next(i, newArr.Length - 1)
            let temp = newArr.[i]
            newArr.[i] <- newArr.[rndIndex]
            newArr.[rndIndex] <- temp
        newArr