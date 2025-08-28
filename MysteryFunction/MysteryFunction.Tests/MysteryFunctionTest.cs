using NUnit.Framework;
using System;

public class MysteryFunctionTest
{
    [Test, Order(1)]
    public void MysteryTest()
    {
        Assert.That(MysteryFunction.Mystery(6), Is.EqualTo(5), "mystery(6) ");
        Assert.That(MysteryFunction.Mystery(9), Is.EqualTo(13), "mystery(9) ");
        Assert.That(MysteryFunction.Mystery(19), Is.EqualTo(26), "mystery(19) ");
    }

    [Test, Order(2)]
    public void MysteryInvTest()
    {
        Assert.That(MysteryFunction.MysteryInv(5), Is.EqualTo(6), "mysteryInv(5)");
        Assert.That(MysteryFunction.MysteryInv(13), Is.EqualTo(9), "mysteryInv(13)");
        Assert.That(MysteryFunction.MysteryInv(26), Is.EqualTo(19), "mysteryInv(26)");
    }
}