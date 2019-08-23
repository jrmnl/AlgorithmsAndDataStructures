using System;

namespace CormenIntoductionToAlgorithms.Extensions
{
    internal static class IntExtensions
    {
        public static int Pow(this int value, int degree)
        {
            if (degree < 1) throw new InvalidOperationException();

            var powed = value;
            for (int i = 2; i <= degree; i++)
            {
                powed *= value;
            }
            return powed;
        }
    }
}
