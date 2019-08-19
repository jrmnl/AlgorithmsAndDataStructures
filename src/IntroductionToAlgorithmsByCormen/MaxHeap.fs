namespace IntroductionToAlgorithmsByCormen

open System.Linq

type MaxHeap(array:int[]) =
    let _array = array.ToList()

    let left i = ((i+1)*2)-1
    let right i = (i+1)*2

    let rec maxHeapify i =
        let left = left i
        let right = right i
        let mutable largest = i
        if left < _array.Count && _array.[left] > _array.[i] then
            largest <- left
        if right < _array.Count && _array.[right] > _array.[largest] then
            largest <- right
        if largest <> i then
            let temp = _array.[i]
            _array.[i] <- _array.[largest]
            _array.[largest] <- temp
            maxHeapify largest

    let ctor() =
        for i = (_array.Count - 1) / 2 downto 0 do
            maxHeapify i
    do ctor()

    /// Removes root element
    member this.Pop() =
        let temp = _array.[0]
        _array.[0] <- _array.[_array.Count]
        _array.RemoveAt(_array.Count - 1)
        maxHeapify 0
        temp