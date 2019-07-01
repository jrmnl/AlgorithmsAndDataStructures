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