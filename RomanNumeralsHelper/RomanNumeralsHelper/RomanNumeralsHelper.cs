public class RomanNumerals
{
    public static string ToRoman(int n)
    {


        if (n == 0 || n > 4000) return "";

        VarStep varStep = new VarStep();

        varStep.response = "";
        varStep.n = n;
        varStep.div = 1;
        varStep.rest = 0;
        varStep.q = 0;

        do
        {
            if (n >= 1000)
            {
                varStep.C = 'M';
                addToResponseLetter(varStep);

            }
            else if (1000 < n && n >= 500)
            {

            }
            else if (n < 500 && n >= 100)
            {

            }
            else if (n < 100 && n >= 50)
            {

            }
            else if (n < 50 && n >= 10)
            {

            }
            else if (n < 10 && n >= 5)
            {

            }
            else
            {

                while (varStep.q >= 0)
                {
                    varStep.response += "I";
                }
            }
        }
        while (varStep.rest >= 1);

        return varStep.response;
    }

    public class VarStep
    {
        public string response { get; set; } = "";
        public int n { get; set; }
        public int div { get; set; }
        public int q { get; set; }
        public int rest { get; set; }
        public char C { get; set; }

    }

    public static string addToResponseLetter(VarStep varStep)
    {
        varStep.rest = varStep.n % varStep.div;
        varStep.q = varStep.n / varStep.div;
        varStep.n = varStep.q * varStep.div - varStep.rest;

        while (varStep.q >= 0)
        {
            varStep.response += varStep.C;
        }
        return varStep.response;
    }

    public static int FromRoman(string romanNumeral)
    {
        return 0;
    }


}