namespace IntroductionToAlgorithmsByCormen

module Exercises =

    // 2.1-4
    // Consider the problem of adding two n-bit binary integers, stored 
    // in two n-element arrays A and B. The sum of the two integers
    // should be stored in binary form in an (n+1)-element array C.
    // Remark: done in little endian 
    let binaryAdd (fst:bool[]) (snd:bool[]) =
        if (fst.Length <> snd.Length)
        then invalidArg "snd" "Arrays should be same length"

        let result = Array.zeroCreate (fst.Length + 1)
        for i = 0 to result.Length - 2 do
            let current, curry = BinaryUtils.add3 result.[i] fst.[i] snd.[i]
            result.[i] <- current
            result.[i + 1] <- curry
        result

    // 2.3-7
    // Describe a Θ(nlgn)-time algorithm that, given a set S of n integers
    // and another integer x, determines whether or not there exist
    // two elements in S whose sum is exactly x.
    let findContainsSum (sum:int) (array:int[]) =
        let rec loop index (array:int[]) =
            if (index < array.Length - 2)
            then
                let key = sum - array.[index]
                let indexOfKey = array |> BinarySearch.tryFindIndexStarts (index + 1) key
                match indexOfKey with
                | Some _ -> true
                | None -> array |> loop (index + 1)
            else false
    
        // nlgn
        let sortedArray = MergeSort.sort array
        // nlgn
        sortedArray |> loop 0
            
