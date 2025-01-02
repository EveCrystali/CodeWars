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
            strings.Add(RemoveIChar(i , input));
            Console.WriteLine($"New string added by RemoveIChar : {strings.Last()}");
            foreach(string s in strings)
            {
                permutations =[.. LinearInsert(input[i], s)];
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
        Console.WriteLine($"linearPermations are : {string.Join(",", linearPermutations)}");
        return linearPermutations;
    }
    private static string RemoveIChar(int i, string input)
    {
        return string.Concat(input[..i], input[(i+1)..]);
    }

}