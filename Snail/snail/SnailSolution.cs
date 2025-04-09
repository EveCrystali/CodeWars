using System.Collections.Generic;
using System.Linq;
using System;

public class SnailSolution
{
    public static int[] Snail(int[][] array)
    {
        if (array.Length == 0 || array[0].Length == 0)
        {
            return new int[0];
        }

        int[] headOfSnail = [0, 0];
        int[] snailDirection = [0, 0];
        List<(int, int)> alreadyAdded = [];
        List<int> result = [array[0][0]];
        int columns = array[0].Length;
        int rows = array.Length;

        alreadyAdded.Add((headOfSnail[0], headOfSnail[1]));

        if (alreadyAdded.Count == 1)
        {
            snailDirection[0] = 0;
            snailDirection[1] = 1;
        }
        else
        {

            GetSnailDirection(array, headOfSnail, snailDirection, alreadyAdded);
        }

        while (alreadyAdded.Count < columns * rows)
        {
            if (ChangeDirectionNeeded(array, alreadyAdded, headOfSnail, snailDirection))
            {
                GetSnailDirection(array, headOfSnail, snailDirection, alreadyAdded);
            }

            headOfSnail[0] += snailDirection[0];
            headOfSnail[1] += snailDirection[1];

            alreadyAdded.Add((headOfSnail[0], headOfSnail[1]));

            result.Add(array[headOfSnail[0]][headOfSnail[1]]);
        }
        return result.ToArray();
    }

    private static Dictionary<(int, int), int> GetSurroundings(int[][] array, int[] headOfSnail, List<(int, int)> alreadyAdded)
    {
        int rows = array.Length;
        int columns = array[0].Length;
        int currentRow = headOfSnail[0];
        int currentColumn = headOfSnail[1];

        (int RowOffset, int ColOffset)[] offsets = [(-1, 0), (0, -1), (0, 1), (1, 0)];

        Dictionary<(int, int), int> surroundings = [];

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

    private static void GetSnailDirection(int[][] array, int[] headOfSnail, int[] snailDirection, List<(int, int)> alreadyAdded)
    {
        Dictionary<(int, int), int> surroundingsAvailable = GetSurroundings(array, headOfSnail, alreadyAdded);

        if (surroundingsAvailable.Count > 0)
        {
            KeyValuePair<(int, int), int> min = surroundingsAvailable.MinBy(x => x.Value);

            snailDirection[0] = min.Key.Item1 - headOfSnail[0];
            snailDirection[1] = min.Key.Item2 - headOfSnail[1];
        }
    }

    // Do we need to change direction of the snail ? Yes if we hit a border or a position already added to the snail
    private static bool ChangeDirectionNeeded(int[][] array, List<(int, int)> alreadyAdded, int[] headOfSnail, int[] snailDirection)
    {
        if (alreadyAdded.Contains((headOfSnail[0] + snailDirection[0], headOfSnail[1] + snailDirection[1])))
        {
            return true;
        }
        if (ExitingTheMatrix(array, headOfSnail, snailDirection))
        {
            return true;
        }
        return false;
    }

    private static bool ExitingTheMatrix(int[][] array, int[] headOfSnail, int[] snailDirection)
    {
        int rows = array.Length;
        int columns = array[0].Length;

        if (headOfSnail[0] + snailDirection[0] >= rows || headOfSnail[1] + snailDirection[1] >= columns || headOfSnail[0] + snailDirection[0] < 0 || headOfSnail[1] + snailDirection[1] < 0)
        {
            return true;
        }
        return false;
    }
}
