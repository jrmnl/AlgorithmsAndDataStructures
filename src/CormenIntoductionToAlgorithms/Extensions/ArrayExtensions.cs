using System;

namespace CormenIntoductionToAlgorithms.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] CopySubarray<T>(this T[] array, int begin, int end)
        {
            var newArray = new T[end - begin + 1];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = array[i + begin];
            }
            return newArray;
        }

        public static T? GetElementOrNull<T>(this T[] array, int index) where T : struct
        {
            if (index < 0) throw new InvalidOperationException();
            if (index >= array.Length) return null;
            return array[index];
        }
    }
}