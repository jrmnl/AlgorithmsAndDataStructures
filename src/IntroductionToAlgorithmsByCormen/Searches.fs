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
    /// Find element in sorted array
    let tryFindIndex element (array:'T[]) = 
        let rec find start finish =
            let len = start + finish
            let mid = len / 2
            if (array.[mid] = element)
            then Some mid
            elif (array.[mid] > element && mid > start)
            then find start (mid - 1)
            elif (array.[mid] < element && mid < finish)
            then find (mid + 1) finish
            else None

        if (array.Length = 0)
        then None
        else find 0 (array.Length - 1)
