using System;
using System.Collections.Generic;
public class Permutations
{
    public static List<string> SinglePermutations(string input)
    {
        HashSet<string> permutations = [];

        if (input.Length == 1) return [input];

        HashSet<string> strings = [];

        for (int i = 0; i < input.Length; i++)
        {
            string reduceStringI = RemoveIChar(i , input);
            Console.WriteLine($"New string added by RemoveIChar : {reduceStringI.Last()}");
            foreach(string permutation in SinglePermutations(reduceStringI))
            {
                foreach(string newPermutation in LinearInsert(input[i], permutation))
                {
                    permutations.Add(newPermutation);
                }
            }
        }
        Console.WriteLine($"Resulat : {string.Join(",", permutations)}");
        return [..permutations];
    }

    private static List<string> LinearInsert(char c, string s)
    {
        List<string> linearPermutations = [];

        for(int i =0; i <= s.Length ; i++)
        {
            linearPermutations.Add(string.Concat(s[..i], c, s[i..]));
        }
        Console.WriteLine($"linearPermutations are : {string.Join(",", linearPermutations)}");
        return linearPermutations;
    }
    private static string RemoveIChar(int i, string input)
    {
        return string.Concat(input[..i], input[(i+1)..]);
    }

}