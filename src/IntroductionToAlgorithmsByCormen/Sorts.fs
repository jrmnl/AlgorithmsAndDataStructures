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

module BubbleSort =
    let sort array =
        let arr = Array.copy array
        for i = 0 to arr.Length - 1 do
            for j = arr.Length - 1 downto 1 do
                if (arr.[j] < arr.[j - 1])
                then
                    let temp = arr.[j]
                    arr.[j] <- arr.[j]
                    arr.[j - 1] <- temp
        arr

module MergeSort =
    let private merge start mid _end (arr:'a[]) =
        let leftLen = mid - start + 1
        let left = Array.zeroCreate (leftLen + 1)
        for i = 0 to leftLen - 1 do 
            left.[i] <- Some arr.[start + i]
            
        let rightLen = _end - mid
        let right = Array.zeroCreate (rightLen + 1)
        for i = 0 to rightLen - 1 do 
            right.[i] <- Some arr.[mid + 1 + i]

        let mutable l = 0
        let mutable r = 0
        for i = start to _end do
            match left.[l], right.[r] with
            | Some left, Some right ->
                if (left < right)
                then
                    arr.[i] <- left
                    l <- l + 1
                else
                    arr.[i] <- right
                    r <- r + 1
            | Some left, None ->
                arr.[i] <- left
                l <- l + 1
            | None, Some right ->
                arr.[i] <- right
                r <- r + 1
            | _ -> failwith "fatal"

    let rec private mergeSort start finish array = 
        if (start < finish)
        then
            let mid = (start + finish) / 2
            array |> mergeSort start mid
            array |> mergeSort (mid + 1) finish
            array |> merge start mid finish

    let sort array =
        let arr = Array.copy array
        arr |> mergeSort 0 (arr.Length - 1)
        arr

module MergeSortFunctionally =

    let rec private merge (left:'a list) (right:'a list) =
        match left, right with
        | lHead::lTail, rHead::rTail ->
            if (lHead < rHead)
            then lHead :: (merge lTail right)
            else rHead :: (merge rTail left)
        | _::_, [] -> left
        | [], _::_ -> right
        | [], [] -> []

    let rec sort list = 
        match list with
        | [] -> []
        | [head] -> [head]
        | _ -> 
             let (left, right) = list |> List.splitAt (list.Length / 2)
             let sortedLeft = sort left
             let sortedRight = sort right
             merge sortedLeft sortedRight