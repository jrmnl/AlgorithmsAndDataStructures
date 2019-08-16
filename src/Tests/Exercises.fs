module Tests.Exercises

open FsCheck.Xunit
open IntroductionToAlgorithmsByCormen
open MathNet.Numerics.LinearAlgebra

[<Property>]
let ``Binary adding works correctly`` () =
    let fst = [| true; false; true; true |]
    let snd = [| false; false; true; false |]
    let expected = [| true; false; false; false; true |]

    let result = Exercises.binaryAdd fst snd

    result |> SeqUtils.seqEqual expected

[<Property>]
let ``Contains sum in positive scenario`` () =
    [| 15; 4344; 654; 767; 4545 |]
    |> Exercises.findContainsSum (654 + 4545)

[<Property>]
let ``Contains sum in negative scenario`` () =
    [| 15; 4344; 654; 767; 4545 |]
    |> Exercises.findContainsSum (16 + 767)
    |> not

[<Property>]
let ``Contains sum not calculates first element twice`` () =
    [| 50; 0 |]
    |> Exercises.findContainsSum 100
    |> not

[<Property>]
let ``Contains sum on empty array`` () =
    Array.empty
    |> Exercises.findContainsSum (123)
    |> not

[<Property>]
let ``Find max subarray`` () =
    let ints =
        [| 13; -3; -25; 20; -3; -16; -23;
           18; 20; -7; 12;
           -5; -22; 15; -4; 7|]

    let result = ints |> Exercises.findMaxSubarray

    result = (7, 10, 43)
    
[<Property>]
let ``Find max subarray on all negative ints`` () =
    let ints = [| -25; -3; -3; -16; -23; -7; -5; -22; -4; |]
    let result = ints |> Exercises.findMaxSubarray
    result = (1, 1, -3)

    
[<Property>]
let ``Find max subarray (brute force version)`` () =
    let ints =
        [| 13; -3; -25; 20; -3; -16; -23;
            18; 20; -7; 12;
            -5; -22; 15; -4; 7|]
    
    let result = ints |> Exercises.findMaxSubarrayBrute
    
    result = (7, 10, 43)

[<Property>]
let ``Find max subarray (linear version)`` () =
    let ints =
        [| 13; -3; -25; 20; -3; -16; -23;
            18; 20; -7; 12;
            -5; -22; 15; -4; 7|]
        
    let result = ints |> Exercises.findMaxSubArrayLinear
        
    result = (7, 10, 43)

[<Property>]
let ``Standard square matrix multiply`` () =
    let fisrt = array2D [ [1.0; 54.0; 3.0]; [6.0; 45.0; 6.0]; [78.0; 34.0; 12.0] ]
    let second = array2D [ [11.0; 2.0; 4.0]; [12.0; 6.0; 67.0]; [66.0; 88.0; 99.0] ]
    let a = DenseMatrix.ofArray2 fisrt
    let b = DenseMatrix.ofArray2 second
    let expectedResult = a.Multiply(b)

    let result = Exercises.multiplySquareMatrix fisrt second |> DenseMatrix.ofArray2

    result = expectedResult