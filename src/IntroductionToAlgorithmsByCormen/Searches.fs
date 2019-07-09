namespace IntroductionToAlgorithmsByCormen


module LinearSearch =
    let tryFindIndex (element:'T) (array:'T[]) =
        let rec loop i =
            if (i >= array.Length)
            then None
            elif (array.[i] = element)
            then Some i
            else loop (i + 1)
        loop 0

module BinarySearch =
    /// Find element in sorted array
    let tryFindIndex (element:'T) (array:'T[]) = 
        let rec find (start:int) finish =
            let len = start + finish
            let mid = len / 2
            if (array.[mid] = element)
            then Some mid
            elif (mid <> start && array.[mid] > element)
            then find start (mid - 1)
            elif (mid <> finish && array.[mid] < element)
            then find (mid + 1) finish
            else None

        if (array.Length = 0)
        then None
        else find 0 (array.Length - 1)
