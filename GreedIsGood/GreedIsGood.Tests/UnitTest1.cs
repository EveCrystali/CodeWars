using System;
using NUnit.Framework;

public static class ScoreChecker
{
  [Test]
  public static void ShouldBeWorthless()
  {
    Assert.That(Kata.Score(new int[] {2, 3, 4, 6, 2}), Is.EqualTo(0));
  }
  
  [Test]
  public static void ShouldValueTriplets()
  {
    Assert.That(Kata.Score(new int[] {4, 4, 4, 3, 3}), Is.EqualTo(400));
  }
  
  [Test]
  public static void ShouldValueMixedSets()
  {
    Assert.That(Kata.Score(new int[] {2, 4, 4, 5, 4}), Is.EqualTo(450));
  }
}