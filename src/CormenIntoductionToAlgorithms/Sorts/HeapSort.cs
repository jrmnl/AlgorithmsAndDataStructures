using CormenIntoductionToAlgorithms.DataStructures;

namespace CormenIntoductionToAlgorithms.Sorts;

public static class HeapSort
{
    public static void Sort(int[] array)
    {
        var heap = new Heap(array, Heap.OrderType.Min);
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = heap.Pop();
        }
    }
}