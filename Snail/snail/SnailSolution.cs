
namespace snail;

public class SnailSolution
{
    public static int[] Snail(int[][] array)
    {
        int[] result = [array[0][0]];
        int columns = array[0].Length;
        int rows = array.Length;
        int[] ij = [0, 0];

        List<(int, int)> alreadyAdded = [];

        alreadyAdded.Add((ij[0], ij[1]));

        Dictionary<(int, int), int> surroundingsAvailable = new Dictionary<(int, int), int>();

        // First loop ensuring that all cells have been added
        while (alreadyAdded.Count <= columns * rows)
        {
            surroundingsAvailable = getSurroundings(array, ij, alreadyAdded);
            if (surroundingsAvailable.Count > 0)
            {
                KeyValuePair<(int, int), int> min = surroundingsAvailable.MinBy(x => x.Value);
                result = [.. result, min.Value];
                alreadyAdded.Add(min.Key);
                ij[0] = min.Key.Item1;
                ij[1] = min.Key.Item2;
            }
            else
            {
                break;
            }
        }

        return result;
    }
    private Dictionary<(int, int), int> GetSurroundings(int[][] array, int[] headOfSnail, List<(int, int)> alreadyAdded)
    {
        int rows = array.Length;
        int columns = array[0].Length;
        int currentRow = headOfSnail[0];
        int currentColumn = headOfSnail[1];

        (int RowOffset, int ColOffset)[] offsets = new (int RowOffset, int ColOffset)[]
        {
        (-1, 0), (0, -1), (0, 1), (1, 0)
        };

        Dictionary<(int, int), int> surroundings = new Dictionary<(int, int), int>();

        foreach ((int rowOffset, int colOffset) in offsets)
        {
            int adjacentRow = Math.Clamp(currentRow + rowOffset, 0, rows - 1);
            int adjacentColumn = Math.Clamp(currentColumn + colOffset, 0, columns - 1);

            if (!alreadyAdded.Contains((adjacentRow, adjacentColumn)))
            {
                surroundings[(adjacentRow, adjacentColumn)] = array[adjacentRow][adjacentColumn];
            }
        }
        return surroundings;
    }
}
