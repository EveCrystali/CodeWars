using Xunit;

namespace MovingZerosToTheEnd.Tests;

public class UnitTest1
{
    [Fact]
    public void Test()
    {
      int[] expected = new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0};
      Assert.Equal(expected, Kata.MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}));
    }
}