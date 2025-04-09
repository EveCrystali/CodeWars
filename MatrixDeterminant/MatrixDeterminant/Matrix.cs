public class Matrix
{
    public static int Determinant(int[][] matrix)
    {
        while (matrix[0].Length > 2)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    // Deleting row i
                    int[][] matrix_new = matrix.Where((x, index) => index != i).ToArray();

                    // Deleting column j
                    matrix_new = matrix_new.Select(x => x.Where((y, index) => index != j).ToArray()).ToArray();

                    Determinant(matrix_new);
                }
            }
        }
        if (matrix.Length == 2)
        {
            return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
        }

        return 0;
    }
}