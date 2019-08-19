namespace IntroductionToAlgorithmsByCormen

open System

type MaxHeap(array:int[]) =
    let mutable _heapSize = array.Length
    let _array = Array.copy array

    let left i = ((i+1)*2)-1
    let right i = (i+1)*2

    let rec maxHeapify i =
        let left = left i
        let right = right i
        let mutable largest = i
        if left < _heapSize && _array.[left] > _array.[i] then
            largest <- left
        if right < _heapSize && _array.[right] > _array.[largest] then
            largest <- right
        if largest <> i then
            let temp = _array.[i]
            _array.[i] <- _array.[largest]
            _array.[largest] <- temp
            maxHeapify largest

    let ctor() =
        for i = (_array.Length - 1) / 2 downto 0 do
            maxHeapify i
    do ctor()
    
    member this.HeapSize = _heapSize

    /// Removes root element
    member this.Pop() =
        let temp = _array.[0]
        _array.[0] <- _array.[_heapSize-1]
        _heapSize <- _heapSize - 1;
        maxHeapify 0
        temp