namespace CormenIntoductionToAlgorithms.Searches;

public static class BinarySearch
{
    public static int? Find(int[] array, int element)
    {
        if (array.Length == 0) return null;

        return array.FindRecursively(0, array.Length - 1, element);
    }

    private static int? FindRecursively(this int[] array, int begin, int end, int key)
    {
        var length = begin + end;
        var mid = length / 2;
        if (array[mid] == key)
        {
            return mid;
        }
        else if (array[mid] > key && mid > begin)
        {
            return array.FindRecursively(begin, mid - 1, key);
        }
        else if (array[mid] < key && mid < end)
        {
            return array.FindRecursively(mid + 1, end, key);
        }
        else
        {
            return null;
        }
    }
}