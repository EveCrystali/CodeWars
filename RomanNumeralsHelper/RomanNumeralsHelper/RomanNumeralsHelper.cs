using System.Dynamic;

public class RomanNumerals
{
    public static string ToRoman(int n)
    {
        if (n == 0 || n > 4000) return "";

        VarStep varStep = new() { response = "", n = n, div = Div[0], q = 0, c = C[0] };

        int i = 0;

        do
        {
            addToResponseLetter(varStep);
            if (i + 1 >= Div.Count) break;
            varStep.div = Div[i + 1];
            varStep.c = C[i + 1];
            i++;
        }
        while (varStep.n != 0);

        return varStep.response;

    }

    public static void addToResponseLetter(VarStep varStep)
    {
        varStep.q = varStep.n / varStep.div;
        varStep.n %= varStep.div;
        while (varStep.q > 0)
        {
            varStep.response += varStep.c;
            varStep.q--;
        }
    }

    private static readonly List<int> Div = new List<int> { 1000, 500, 100, 50, 10, 5, 1 };
    private static readonly List<char> C = new List<char> { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };

    public class VarStep
    {
        public string response { get; set; } = "";
        public int n { get; set; }
        public int div { get; set; }
        public int q { get; set; }
        public char c { get; set; }
    }

    public static int FromRoman(string romanNumeral)
    {
        return 0;
    }


}