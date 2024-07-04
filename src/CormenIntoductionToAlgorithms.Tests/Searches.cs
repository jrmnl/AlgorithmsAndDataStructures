using CormenIntoductionToAlgorithms.Searches;
using FsCheck.Xunit;
using CormenIntoductionToAlgorithms.Extensions;

namespace CormenIntoductionToAlgorithms.Tests;

public class Searches
{
    [Property]
    public void LinearSearchTest(int[] array, int element)
    {
        var expected = array.FindIndex(element);
        var founded = LinearSearch.Find(array, element);
        Assert.Equal(expected, founded);
    }

    // TODO
    [Property]
    public void BinarySearchTest(int[] array, int element)
    {
        Array.Sort(array);

        var expected = Array.BinarySearch(array, element);
        var founded = BinarySearch.Find(array, element);
        Assert.Equal(expected < 0 ? null : expected, founded);
    }
}
