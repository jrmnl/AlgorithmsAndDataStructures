namespace CormenIntoductionToAlgorithms.Sorts
{
    public static class BubbleSort
    {
        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > 0; j--)
                {
                    if (array[j] < array[j-1])
                    {
                        var temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                }
            }
        }
    }
}