using NUnit.Framework;
using MaxSequence;

namespace MaxSequence.Test;


using System;
[TestFixture]
public class SolutionTest
{
    [Test, Order(1)]
    public void Test0()
    {
        Assert.That(Kata.MaxSequence(new int[0]), Is.EqualTo(0));
    }
    [Test, Order(2)]
    public void Test1()
    {
        Assert.That(Kata.MaxSequence(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }), Is.EqualTo(6));
    }
}