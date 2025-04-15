using System;
using System.Numerics;
public static class Fibonacci
{
    public static BigInteger fib(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        int absN = n < 0 ? -n : n;

        BigInteger resultABS = MatrixMultiply(MatrixPower([[1, 1], [1, 0]], absN), [[1], [0]])[1][0];

        return (n < 0 && n % 2 == 0) ? -resultABS : resultABS;
    }

    private static BigInteger[][] MatrixPower(BigInteger[][] baseMatrix, int pow)
    {
        if (pow == 0)
            return [[1, 0], [0, 1]];

        if (pow % 2 == 0)
        {
            BigInteger[][] half = MatrixPower(baseMatrix, pow / 2);
            return MatrixMultiply(half, half);
        }
        else
            return MatrixMultiply(MatrixPower(baseMatrix, pow - 1), baseMatrix);
    }

    private static BigInteger[][] MatrixMultiply(BigInteger[][] matrix1, BigInteger[][] matrix2)
    {
        int rowsCountM1 = matrix1.Length;
        int columnsCountM2 = matrix2[0].Length;
        BigInteger[][] result = new BigInteger[rowsCountM1][];
        for (int i = 0; i < rowsCountM1; i++)
        {
            result[i] = new BigInteger[columnsCountM2];
        }

        for (int i = 0; i < rowsCountM1; i++)
        {
            for (int j = 0; j < columnsCountM2; j++)
            {
                for (int k = 0; k < rowsCountM1; k++)
                {
                    result[i][j] += matrix1[i][k] * matrix2[k][j];
                }
            }
        }
        return result;
    }
}