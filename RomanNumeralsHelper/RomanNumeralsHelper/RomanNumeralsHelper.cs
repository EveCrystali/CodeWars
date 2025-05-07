using System.Dynamic;

public class RomanNumerals
{

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

    public static string ToRoman(int n)
    {
        if (n == 0 || n > 4000) return "";

        VarStep varStep = new() { response = "", n = n, div = Div[0], q = 0, c = C[0] };

        do
        {
            AddCharByChar(varStep);
        }
        while (varStep.n != 0);

        return varStep.response;

    }

    public static void AddCharByChar(VarStep varStep)
    {
        varStep.q = varStep.n / varStep.div;

        int currentIndex = Div.IndexOf(varStep.div);

        if (currentIndex + 1 < Div.Count)
        {
            int nextDiv = Div[currentIndex + 1];
            int tempq = varStep.n / nextDiv;
  
            if (tempq == 9 || tempq == 4)
            {
                varStep.response += C[currentIndex + 1].ToString() + C[currentIndex - 1].ToString();
                varStep.n -= tempq * nextDiv;
                return;
            }
        }

        while (varStep.q > 0)
        {
            varStep.response += varStep.c;
            varStep.n -= varStep.div;
            varStep.q--;
        }

        if (currentIndex + 1 < Div.Count)
        {
            varStep.div = Div[currentIndex + 1];
            varStep.c = C[currentIndex + 1];
        }
    }

    public static int FromRoman(string romanNumeral)
    {
        return 0;
    }


}