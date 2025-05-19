using System.Dynamic;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

public static class RomanNumerals
{
    private static readonly (int value, string roman)[] Map =
    [
        (1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I"),
    ];

    public static string ToRoman(int n)
    {
        string response = "";
        for (int i = 0; i < Map.Length; i++)
        {
            while (n / Map[i].value > 0)
            {
                response += Map[i].roman;
                n -= Map[i].value;
            }
        }
        return response;
    }

    public static int FromRoman(string romanNumeral)
    {
        int response = 0;
        int i = 0;
        while (i < romanNumeral.Length)
        {
            bool match = false;
            foreach ((int value, string numeral) in Map)
            {
                if (romanNumeral[i..].StartsWith(numeral))
                {
                    response += value;
                    i += numeral.Length;
                    match = true;
                    break;
                }
            }
            if (!match)
            {
                i++;
            }
        }
        return response;
    }
}