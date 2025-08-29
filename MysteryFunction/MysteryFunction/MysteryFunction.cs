using System;

namespace Kata;

public static class MysteryFunction
{
    public static long Mystery(long n) => n ^ (n >> 1);

    public static long MysteryInv(long n)
    {
        if (n == 0)
        {
            return 0;
        }

        return n ^ MysteryInv(n >> 1);
    }

    public static string NameOfMystery() => "gray code";

}