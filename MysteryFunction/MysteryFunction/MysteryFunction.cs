using System;

namespace Kata;

public class MysteryFunction
{
    public static long Mystery(long n)
    {
        long resultat = n;
        for (int i = 0; i <= 62; i++)
        {
            // On parcours bit par bit n pour appliquer la logique de conversion

            // On fabrique un long dont tous les bits sont nuls sauf celui en position i qui vaut 1
            long masque = 1L << i;

            // Si le bit en position i de n vaut 1 alors on veut que le bit suivant dans notre résultat vaut 1 sauf si il est déjà sur 1 alors on veut 0
            if ((n & masque) != 0)
            {
                long masque2 = 1L << i + 1;

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
        return -1;
    }

    public static string NameOfMystery(int n) => $"mystery({n})";

}