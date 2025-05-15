using System.Dynamic;
using System.Numerics;
using System.Collections.Generic;

public class RomanNumerals
{

    private static readonly List<int> Div = new List<int> { 1000, 500, 100, 50, 10, 5, 1 };
    private static readonly List<char> C = new List<char> { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };

    public class ConversionToRomanState
    {
        public string Response { get; set; } = "";
        public int N { get; set; }
        public int Div { get; set; }
        public int Q { get; set; }
        public char C { get; set; }
    }

    public static string ToRoman(int n)
    {
        if (n == 0 || n > 4000) return "";

        ConversionToRomanState state = new() { Response = "", N = n, Div = Div[0], Q = 0, C = C[0] };

        do
        {
            AddCharByChar(state);
        }
        while (state.N != 0);

        return state.Response;

    }

    public static void AddCharByChar(ConversionToRomanState state)
    {
        state.Q = state.N / state.Div;

        int currentIndex = Div.IndexOf(state.Div);

        if (currentIndex + 1 < Div.Count)
        {
            int nextDiv = Div[currentIndex + 1];
            int tempq = state.N / nextDiv;

            if (tempq == 9 || tempq == 4)
            {
                state.Response += C[currentIndex + 1].ToString() + C[currentIndex - 1].ToString();
                state.N -= tempq * nextDiv;
                return;
            }
        }

        while (state.Q > 0)
        {
            state.Response += state.C;
            state.N -= state.Div;
            state.Q--;
        }

        if (currentIndex + 1 < Div.Count)
        {
            state.Div = Div[currentIndex + 1];
            state.C = C[currentIndex + 1];
        }
    }

    public static int FromRoman(string romanNumeral)
    {
        int response = 0;

        for (int i = 0; i < romanNumeral.Length; i++)
        {
            char c1 = romanNumeral[i];
            int indexC1 = C.IndexOf(c1);
            response += Div[indexC1];
        }

        return response;
    }
}