using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class SolutionTest
{
    [Test, Order(1)]
    public void Example1()
    {
        Assert.That(Permutations.SinglePermutations("a").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "a" }));
    }

    [Test, Order(2)]
    public void Example2()
    {
        Assert.That(Permutations.SinglePermutations("ab").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "ab", "ba" }));
    }

    [Test, Order(3)]
    public void Example3()
    {
        Assert.That(Permutations.SinglePermutations("aabb").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "aabb", "abab", "abba", "baab", "baba", "bbaa" }));
    }
}
