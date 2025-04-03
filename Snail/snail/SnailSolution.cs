
namespace snail;

public class SnailSolution
{
    public static int[] Snail(int[][] array)
    {
        int[] result = [array[0][0]];
        int columns = array[0].Length;
        int rows = array.Length;

        int[] ij = [0, 0];

        List<int[]> alreadyAdded = [ij];

        while (alreadyAdded.Count <= columns * rows)
        {

        }

        return result;

    }
}