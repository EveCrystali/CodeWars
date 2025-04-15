using System;
using System.Numerics;
public class Fibonacci
{
    public static BigInteger fib(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        BigInteger resultN2 = 0;
        BigInteger resultN1 = 1, resultN0 = 0;
        int m;

        if (n < 0)
        {
            m = -n;
        }
        else
        {
            m = n;
        }

        for (int i = 1; i < m; i++)
        {
            resultN2 = resultN1 + resultN0;
            resultN0 = resultN1;
            resultN1 = resultN2;

        }

        if (n < 0 && m % 2 == 0)
        {
            return -resultN2;
        }

        return resultN2;
    }
}