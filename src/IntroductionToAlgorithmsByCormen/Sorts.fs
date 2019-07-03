namespace IntroductionToAlgorithmsByCormen

module InsertionSort =
    let private sort compare array =
        let arr = Array.copy array
        for i = 1 to arr.Length - 1 do
            let key = arr.[i]
            let mutable j = i - 1
            while j >= 0 && compare arr.[j] key do
                arr.[j + 1] <- arr.[j]
                j <- j - 1
            arr.[j + 1] <- key
        arr
        
    let sortAsc array =
        array |> sort (fun x y -> x > y)

    let sortDesc array =
        array |> sort (fun x y -> x < y)

module SelectionSort =
    let sort array =
        let arr = Array.copy array
        for i = 0 to arr.Length - 2 do
            let mutable min = i
            for j = i + 1 to arr.Length - 1 do
                if (arr.[j] < arr.[min])
                then min <- j
            let temp = arr.[i]
            arr.[i] <- arr.[min]
            arr.[min] <- temp
        arr