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