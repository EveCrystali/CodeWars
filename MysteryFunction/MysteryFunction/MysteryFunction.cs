using System;

namespace Kata;

public static class MysteryFunction
{
    public static long Mystery(long n)
    {
        long resultat = n;

        for (int i = 63; i > 0; i--)
        {
            long masque = 1L << i;

            if ((n & masque) != 0)
            {
                long masque2 = 1L << i - 1;

                if ((n & masque2) != 0)
                {
                    resultat &= ~masque2;
                }
                else
                {
                    resultat |= masque2;
                }
            }
        }

        return resultat;
    }

    public static long MysteryInv(long n)
    {
        long resultat = n;

        for (int i = 63; i > 0 ; i--)
        {
            long masque = 1L << i;

            if ((resultat & masque) != 0)
            {
                long masque2 = 1L << i - 1;

                if ((n & masque2) != 0)
                {
                    resultat &= ~masque2;
                }
                else
                {
                    resultat |= masque2;
                }
            }
        }
        return resultat;
    }

    public static string NameOfMystery() => "gray code";

}