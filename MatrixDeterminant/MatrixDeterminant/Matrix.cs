using System.Collections.Generic;
using System.Linq;
using System;

public class Matrix
{
    public static int Determinant(int[][] matrix)
    {
        int result = 0;

        if (matrix.Length == 0)
        {
            return 0;
        }
        if (matrix.Length == 1)
        {
            return matrix[0][0];
        }
        if (matrix.Length == 2)
        {
            return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
        }

        for (int j = 0; j < matrix[0].Length; j++)
        {
            // Deleting row 0
            int[][] matrix_new = matrix.Where((x, index) => index != 0).ToArray();

            // Deleting column j
            matrix_new = matrix_new.Select(x => x.Where((y, index) => index != j).ToArray()).ToArray();

            result += (int)Math.Pow(-1, j) * matrix[0][j] * Determinant(matrix_new);
        }

        return result;
    }
}