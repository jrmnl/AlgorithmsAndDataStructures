using System;
using System.Linq;
using CormenIntoductionToAlgorithms.Extensions;

namespace CormenIntoductionToAlgorithms.Utilities
{
    public static class ArrayShuffler
    {
        public static void ShuffleInPlace(int[] array)
        {
            var rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                var rndIndex = rnd.Next(i, array.Length - 1);
                var temp = array[i];
                array[i] = array[rndIndex];
                array[rndIndex] = temp;
            }
        }

        public static void ShuffleBySorting(int[] array)
        {
            var rnd = new Random();
            var maxRnd = array.Length.Pow(3);
            var withPriorities = array
                .Select(x => (Priority: rnd.Next(0, maxRnd), Value: x))
                .OrderBy(x => x.Priority)
                .ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = withPriorities[i].Value;
            }
        }
    }
}