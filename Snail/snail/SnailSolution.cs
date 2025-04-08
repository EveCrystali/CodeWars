
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

    private static Dictionary<(int, int), int> getSurroundings(int[][] array, int[] ij, List<(int, int)> alreadyAdded)
    {
        Dictionary<(int, int), int> surroundings = new Dictionary<(int, int), int>();
        int rows = array.Length;
        int columns = array[0].Length;
        int i = ij[0];
        int j = ij[1];

        // Définir les déplacements possibles (voisins)
        int[] rowOffsets = { -1, 0, 0, 1 };
        int[] colOffsets = { 0, -1, 1, 0 };

        for (int k = 0; k < rowOffsets.Length; k++)
        {
            int newRow = i + rowOffsets[k];
            int newCol = j + colOffsets[k];

            // Vérifier si les nouvelles coordonnées sont valides (dans les limites du tableau)
            if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < columns && !alreadyAdded.Contains((newRow, newCol)))
            {
                surroundings.Add((newRow, newCol), array[newRow][newCol]);
            }
        }

        return surroundings;
    }
}
