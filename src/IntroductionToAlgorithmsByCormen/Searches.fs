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
    let rec private find (start:int) finish (element:'T) (array:'T[]) =
        let len = start + finish
        let mid = len / 2
        if (array.[mid] = element)
        then Some mid
        elif (mid <> start && array.[mid] > element)
        then array |> find start (mid - 1) element
        elif (mid <> finish && array.[mid] < element)
        then array |> find (mid + 1) finish element
        else None

    /// Find element in sorted array
    let tryFindIndex (element:'T) (array:'T[]) = 
        if (array.Length = 0)
        then None
        else array |> find 0 (array.Length - 1) element
