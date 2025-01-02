using System;
using System.Collections.Generic;
public class Permutations
{
    public static List<string> SinglePermutations(string input)
    {
        // Il y a n! permutations

        if (input.Length == 1) return [input];

        HashSet<string> preAnswer = [];

        for (int i = 0; i < input.Length - 1; i++)
        {
            string inputWithoutIChar = RemoveCharAtIndex(i, input);

            HashSet<string> linearPermutation = [.. LinearPermutationAuto(i, inputWithoutIChar)];

            foreach (string s in linearPermutation)
            {
                preAnswer = [.. preAnswer, .. SinglePermutations(s)];
            }
        }
        Console.WriteLine(preAnswer.ToString());
        return [.. preAnswer];
    }

    private static List<string> LinearPermutationAuto(int index, string input)
    {
        List<string> strings = [];
        for (int i = 0; i < input.Length; i++)
        {
            strings.Add(InsertChar(i, input[index], RemoveCharAtIndex(index, input)));
        }
        return strings;
    }


    private static string InsertChar(int index, char c, string input)
    {
        return string.Concat(input.AsSpan(0, index).ToString(), c, input.AsSpan(index).ToString());
    }

    private static string RemoveCharAtIndex(int index, string input)
    {
        return string.Concat(input.AsSpan(0, index), input.AsSpan(index + 1));
    }
}