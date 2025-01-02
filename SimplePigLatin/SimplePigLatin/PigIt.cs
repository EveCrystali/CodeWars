using System;
using System.Text.RegularExpressions;

namespace Kata;
public partial class Kata
{
  public static string PigIt(string str)
  {
    int i = 0;

    while (i < str.Length)
    {

      if (!RegexWord().IsMatch(str[i].ToString()))
      {
        i++;
        continue;
      }

      int j = i;

      while (j < str.Length && RegexWord().IsMatch(str[j].ToString()))
      {
        j++;
      }

      str = str.Insert(j, str[i] + Ay);
      str = str.Remove(i, 1);

      i = j + Ay.Length;
    }

    return str;
  }

  [GeneratedRegex("\\w")]
  private static partial Regex RegexWord();

  private static readonly string Ay = "ay";
}