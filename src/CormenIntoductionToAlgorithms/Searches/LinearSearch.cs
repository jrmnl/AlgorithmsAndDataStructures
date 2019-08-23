namespace CormenIntoductionToAlgorithms.Searches
{
    public static class LinearSearch
    {
        public static int? Find(int[] array, int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }
            return null;
        }
    }
}
