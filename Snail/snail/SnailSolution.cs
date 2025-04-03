
namespace snail;

public class SnailSolution
{
    public static int[] Snail(int[][] array)
    {
        int[] result = [array[0][0]];
        int columns = array[0].Length;
        int rows = array.Length;

        int i = 0;
        int j = 0;

        int[] ij = [i, j];
        

        List<(int, int)> alreadyAdded = []

        alreadyAdded.Add((i, j));

        Dictionary<(int, int), int> surroundingsAvailable = new Dictionary<(int, int), int>();


        // First loop ensuring that all cells have been added
        while (alreadyAdded.Count <= columns * rows)
        {
            surroundingsAvailable = getSurroundings(array, ij alreadyAdded);
            if (surroundingsAvailable.Count > 0)
            {
                var min = surroundingsAvailable.MinBy(x => x.Value);
                result.Add(min.Value);
                alreadyAdded.Add(min.Key);
                i = min.Key.Item1;
                j = min.Key.Item2;
            }
            else
            {
                break;
            }
        }

        return result;
    }


    Dictionary<(int, int), int> getSurroundings(int[][] array, int[] ij, List<(int, int)> alreadyAdded)
    {
        Dictionary<(int, int), int> surroundings = new Dictionary<(int, int), int>();
        int rows = array.Length;
        int columns = array[0].Length;
        int i = ij[0];
        int j = ij[1];

        // Définir les déplacements possibles (voisins)
        int[] rowOffsets = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] colOffsets = { -1, 0, 1, -1, 1, -1, 0, 1 };

        for (int k = 0; k < rowOffsets.Length; k++)
        {
            int newRow = i + rowOffsets[k];
            int newCol = j + colOffsets[k];

            // Vérifier si les nouvelles coordonnées sont valides (dans les limites du tableau)
            if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < columns)
            {
               
                if (!alreadyAdded.Contains(new int[] { newRow, newCol })) 
                {
                    surroundings.Add((newRow, newCol), array[newRow][newCol]);
                }
            }
        }

        return surroundings;
    }
}
