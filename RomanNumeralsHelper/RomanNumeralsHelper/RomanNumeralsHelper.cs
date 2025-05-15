using System.Dynamic;
using System.Numerics;
using System.Collections.Generic;

public static class RomanNumerals
{
    public static string ToRoman(int n) => RomanNumeralConverter.ToRoman(n);
    public static int FromRoman(string romanNumeral) => RomanNumeralConverter.FromRoman(romanNumeral);
}

public static class RomanNumeralConverter
{

    private static readonly List<int> Div = new List<int> { 1000, 500, 100, 50, 10, 5, 1 };
    private static readonly List<char> C = new List<char> { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };

    private const int MAX_ROMAN_VALUE = 4000;
    private const int SUBTRACTIVE_NOTATION_FOUR = 4;
    private const int SUBTRACTIVE_NOTATION_NINE = 9;

    public static string ToRoman(int n)
    {
        if (n == 0 || n > MAX_ROMAN_VALUE) return "";

        ConversionToRomanState state = new() { Response = "", N = n, Divisors = Div[0], Quotient = 0, Char = C[0] };

        do
        {
            AddCharByChar(state);
        }
        while (state.N != 0);

        return state.Response;
    }

    public class ConversionToRomanState
    {
        public string Response { get; set; } = "";
        public int N { get; set; }
        public int Divisors { get; set; }
        public int Quotient { get; set; }
        public char Char { get; set; }
    }

    public static void AddCharByChar(ConversionToRomanState state)
    {
        state.Quotient = state.N / state.Divisors;
        int currentIndex = Div.IndexOf(state.Divisors);

        if (currentIndex + 1 < Div.Count)
        {
            int nextDiv = Div[currentIndex + 1];
            int tempQuotient = state.N / nextDiv;

            if (TryHandleSubtractiveNotation(state, currentIndex, nextDiv, tempQuotient))
            {
                return;
            }
        }

        while (state.Quotient > 0)
        {
            state.Response += state.Char;
            state.N -= state.Divisors;
            state.Quotient--;
        }

        if (currentIndex + 1 < Div.Count)
        {
            state.Divisors = Div[currentIndex + 1];
            state.Char = C[currentIndex + 1];
        }
    }

    private static bool TryHandleSubtractiveNotation(ConversionToRomanState state, int currentIndex, int nextDiv, int tempQuotient)
    {
        if (tempQuotient == SUBTRACTIVE_NOTATION_NINE || tempQuotient == SUBTRACTIVE_NOTATION_FOUR)
        {
            state.Response += C[currentIndex + 1].ToString() + C[currentIndex - 1].ToString();
            state.N -= tempQuotient * nextDiv;
            return true;
        }
        return false;
    }

    public static int FromRoman(string romanNumeral)
    {
        int response = 0;
        int lenght = romanNumeral.Length;
        for (int i = 0; i < lenght; i++)
        {
            char c1 = romanNumeral[i];
            int indexC1 = C.IndexOf(c1);

            if (i + 1 < lenght)
            {
                char c2 = romanNumeral[i + 1];
                int indexC2 = C.IndexOf(c2);

                if (indexC2 < indexC1)
                {
                    response += Div[indexC2] - Div[indexC1];
                    i++;
                    continue;
                }
            }
            response += Div[indexC1];
        }
        return response;
    }
}