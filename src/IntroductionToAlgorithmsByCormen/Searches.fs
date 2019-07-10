namespace IntroductionToAlgorithmsByCormen


module LinearSearch =
    let tryFindIndex element (array:'T[]) =
        let rec loop i =
            if (i >= array.Length)
            then None
            elif (array.[i] = element)
            then Some i
            else loop (i + 1)
        loop 0

module BinarySearch =
    let rec private find key start finish (array:'T[]) =
        let len = start + finish
        let mid = len / 2
        if (array.[mid] = key)
        then Some mid
        elif (array.[mid] > key && mid > start)
        then array |> find key start (mid - 1)
        elif (array.[mid] < key && mid < finish)
        then array |> find key (mid + 1) finish
        else None

    /// Find element in sorted array
    let tryFindIndex key (array:'T[]) = 
        if (array.Length = 0)
        then None
        else array |> find key 0 (array.Length - 1) 
        
    /// Find element in sorted array begining provided index
    let tryFindIndexStarts index key (array:'T[]) = 
        if (array.Length < index)
        then invalidArg "index" "Index out of range"

        if (array.Length = 0)
        then None
        else array |> find key index (array.Length - 1)
