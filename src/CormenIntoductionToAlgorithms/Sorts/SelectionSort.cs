namespace CormenIntoductionToAlgorithms.Sorts;

public static class SelectionSort
{
    public static void Sort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            var min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min])
                {
                    min = j;
                }
            }
            var temp = array[i];
            array[i] = array[min];
            array[min] = temp;
        }
    }
}