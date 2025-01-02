using System;
using NUnit.Framework;
using Kata;

[TestFixture]
public class KataTest
{
  [Test]
  public void KataTests()
  {
    Assert.That(Kata.Kata.PigIt("Pig latin is cool"), Is.EqualTo("igPay atinlay siay oolcay"));
    Assert.That(Kata.Kata.PigIt("This is my string"), Is.EqualTo("hisTay siay ymay tringsay"));
  }
}