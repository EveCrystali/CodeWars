using System;
using System.Numerics;

public class Fibonacci
{

    public static BigInteger fib(int n)
    {
        if (n == 0)
            return BigInteger.Zero;

        if (n == 1)
            return BigInteger.One;

        if (n > 1)
            return fib(n - 1) + fib(n - 2);

        if (n == -1)
            return BigInteger.One;

        if (n < -1)
        {
            return fib(n + 2) - fib(n + 1);
        }

        return BigInteger.Zero;
    }
}