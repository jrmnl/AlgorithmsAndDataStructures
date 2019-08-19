module IntroductionToAlgorithmsByCormen.Exercises

open IntroductionToAlgorithmsByCormen.TupleUtils

// 2.1-4
// Consider the problem of adding two n-bit binary integers, stored 
// in two n-element arrays A and B. The sum of the two integers
// should be stored in binary form in an (n+1)-element array C.
// Remark: done in little endian 
let binaryAdd (fst:bool[]) (snd:bool[]) =
    if (fst.Length <> snd.Length)
    then invalidArg "snd" "Arrays should be same length"

    let result = Array.zeroCreate (fst.Length + 1)
    for i = 0 to result.Length - 2 do
        let current, curry = BinaryUtils.add3 result.[i] fst.[i] snd.[i]
        result.[i] <- current
        result.[i + 1] <- curry
    result

// 2.3-7
// Describe a Θ(nlgn)-time algorithm that, given a set S of n integers
// and another integer x, determines whether or not there exist
// two elements in S whose sum is exactly x.
let findContainsSum (sum:int) (array:int[]) =
    let rec loop index (array:int[]) =
        if (index < array.Length - 2)
        then
            let key = sum - array.[index]
            let indexOfKey = array |> BinarySearch.tryFindIndexStarts (index + 1) key
            match indexOfKey with
            | Some _ -> true
            | None -> array |> loop (index + 1)
        else false
    
    // nlgn
    let sortedArray = MergeSort.sort array
    // n
    sortedArray |> loop 0

// 4.1
// The maximum-subarray problem. Find subarray with highest sum
let private findMaxCrossingSubarray low mid high (array:int[]) =
    let mutable sum = array.[mid]
        
    let mutable leftSum = sum
    let mutable maxLeft = mid
    for i = mid - 1 downto low do
        sum <- sum + array.[i]
        if (sum > leftSum) then
            leftSum <- sum
            maxLeft <- i
        
    sum <- array.[mid + 1]
    let mutable rightSum = sum
    let mutable maxRight = mid + 1
    for i = mid + 2 to high do
        sum <- sum + array.[i]
        if (sum > rightSum) then
            rightSum <- sum
            maxRight <- i
        
    maxLeft, maxRight, leftSum + rightSum

let rec private findMaxSubarrayRec low high (array:int[]) =
    if (low = high)
    then low, high, array.[low]
    else
        let mid = (low + high) / 2
        let leftLow, leftHigh, leftSum =
            array |> findMaxSubarrayRec low mid
        let rightLow, rightHigh, rightSum =
            array |> findMaxSubarrayRec (mid + 1) high
        let crossLow, crossHigh, crossSum =
            array |> findMaxCrossingSubarray low mid high
        if (leftSum >= rightSum && leftSum >= crossSum)
        then leftLow, leftHigh, leftSum
        elif (rightSum >= leftSum && rightSum >= crossSum)
        then rightLow, rightHigh, rightSum
        else crossLow, crossHigh, crossSum
            
let findMaxSubarray (array:int[]) =
    array |> findMaxSubarrayRec 0 (array.Length - 1)

// 4.1-2
// Brute-force method of solving the maximum-subarray problem (4.1)
let findMaxSubarrayBrute (array:int[]) =
    let findMaxSubarrayFrom index =
        let mutable sum = array.[index]
        let mutable maxSum = sum
        let mutable maxSumIndex = index
        for i = index + 1 to array.Length - 1 do
            sum <- sum + array.[i]
            if (sum > maxSum) then
                maxSum <- sum
                maxSumIndex <- i
        index, maxSumIndex, maxSum

    let mutable currentMax = (0, 0, array.[0])
    for i = 0 to array.Length - 1 do
        let result = findMaxSubarrayFrom i
        let prevSum, newSum = thd currentMax, thd result
        if (newSum > prevSum) then
            currentMax <- result

    currentMax

// 4.1-5
// Linear version of solving the maximum-subarray problem (4.1)
let findMaxSubArrayLinear (array:int[]) =
    let mutable left, right, sum = 0, 0, array.[0]
    let mutable tempLeft, tempSum = 0, array.[0]
    for i = 1 to array.Length - 1 do
        tempSum <- max array.[i] (tempSum + array.[i])
        if (tempSum > sum) then
            left <- tempLeft
            right <- i
            sum <- tempSum
        elif (tempSum = array.[i]) then
            tempLeft <- i

    left, right, sum

// 4.2
// Standard matrix multiplication algorithm
let inline multiplySquareMatrix (a:'a[,]) (b:'a[,]) =
    let length = a.GetLength(0)
    let newArr =  Array2D.zeroCreate length length
    for i = 0 to length - 1 do
        for j = 0 to length - 1 do
            for k = 0 to length - 1 do
                newArr.[i,j] <- newArr.[i,j] + a.[i,k] * b.[k,j]
    newArr