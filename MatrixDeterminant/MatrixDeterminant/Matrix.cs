public class Matrix
{
   public static int Determinant(int[][] matrix)
   {
       while (matrix[0].Length > 2)
       {
           for (int i = 0; i < matrix.Length; i++)
           {

           }
       }
       if (matrix.Length == 2)
       {
           return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
       }

       return 0;
   }
}