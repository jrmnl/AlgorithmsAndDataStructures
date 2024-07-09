using CormenIntoductionToAlgorithms.Extensions;

namespace CormenIntoductionToAlgorithms.Sorts;

public static class MergeSort
{
    public static void Sort(int[] array)
    {
        array.SortRecursively(0, array.Length - 1);
    }

    private static void SortRecursively(this int[] array, int begin, int end)
    {
        if (begin < end)
        {
            var mid = (begin + end) / 2;
            array.SortRecursively(begin, mid);
            array.SortRecursively(mid + 1, end);
            array.Merge(begin, mid, end);
        }
    }

    private static void Merge(this int[] array, int begin, int mid, int end)
    {
        var leftArr = array.CopySubarray(begin, mid);
        var rightArr = array.CopySubarray(mid + 1, end);

        var l = 0;
        var r = 0;
        for (int i = begin; i <= end; i++)
        {
            var left = leftArr.GetElementOrNull(l);
            var right = rightArr.GetElementOrNull(r);
            if (left.HasValue && right == null)
            {
                array[i] = left.Value;
                l++;
            }
            else if (right.HasValue && left == null)
            {
                array[i] = right.Value;
                r++;
            }
            else if (left <= right)
            {
                array[i] = left.Value;
                l++;
            }
            else
            {
                array[i] = right!.Value;
                r++;
            }
        }
    }
}
