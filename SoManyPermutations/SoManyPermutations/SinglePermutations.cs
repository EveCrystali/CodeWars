using System;
using System.Collections.Generic;
public class Permutations
{
    public static List<string> SinglePermutations(string input)
    {
        if (input.Length == 1) return [input];

        List<string> preAnswer = [];

        foreach(char c in input)
        {
            preAnswer = [.. preAnswer, .. MoveSpeciedCharAlongTheStringInput(c, input)];
        }
        return preAnswer;
    }

    private static List<string> MoveSpeciedCharAlongTheStringInput(char c, string input)
    {
        List<string> strings = [];
        for(int i = 0 ; i < input.Length ; i++)
        {
            strings.Add(InsertChar(i, c, input));
        }
        return strings;
    }

    private static string InsertChar(int index, char c, string input)
    {
        return string.Concat(input.AsSpan(0, index).ToString(), c, input.AsSpan(index).ToString());
    }

    private static string RemoveCharAtSpecifiedIndex(int index, string input)
    {
        return string.Concat(input.AsSpan(0, index), input.AsSpan(index + 1));
    }
}