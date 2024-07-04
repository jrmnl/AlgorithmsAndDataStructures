using CormenIntoductionToAlgorithms.Sorts;
using FsCheck.Xunit;

namespace CormenIntoductionToAlgorithms.Tests;

public class Sorts
{
    [Property]
    public void InsertionSortTest(int[] array)
    {
        CheckSorting(array, InsertionSort.Sort);
    }

    [Property]
    public void SelectionSortTest(int[] array)
    {
        CheckSorting(array, SelectionSort.Sort);
    }

    [Property]
    public void BubbleSortTest(int[] array)
    {
        CheckSorting(array, BubbleSort.Sort);
    }

    [Property]
    public void MergeSortTest(int[] array)
    {
        CheckSorting(array, MergeSort.Sort);
    }

    [Property]
    public void HeapSortTest(int[] array)
    {
        CheckSorting(array, HeapSort.Sort);
    }

    private static void CheckSorting(int[] array, Action<int[]> sorter)
    {
        sorter(array);
        AssertSorted(array);
    }

    private static void AssertSorted(IReadOnlyList<int> list)
    {
        if (list.Count <= 1)
        {
            Assert.True(true);
            return;
        }

        var current = list[0];
        for (int i = 1; i < list.Count; i++)
        {
            var element = list[i];
            if (element >= current)
            {
                current = element;
            }
            else
            {
                Assert.Fail($"Отличается в индексе [{i-1}:{i}]");
            }
        }

        Assert.True(true);
    }
}
