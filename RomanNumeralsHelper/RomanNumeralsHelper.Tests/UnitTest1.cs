namespace Solution {
  using NUnit.Framework;
  using System;

  // TODO: Replace examples and use TDD by writing your own tests

  [TestFixture]
  public class SolutionTest
  {
    [Test, Order(1)]
    public void TestToRoman_001()
    {
      int input = 1;
      string expected = "I";

      string actual = RomanNumerals.ToRoman(input);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test, Order(2)]
    public void TestToRoman_002()
    {
      int input = 2;
      string expected = "II";

      string actual = RomanNumerals.ToRoman(input);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test, Order(3)]
    public void TestToRoman_003()
    {
      int input = 126;
      string expected = "CXXVI";

      string actual = RomanNumerals.ToRoman(input);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test, Order(4)]
    public void TestToRoman_004()
    {
      int input = 1990;
      string expected = "MCMXC";

      string actual = RomanNumerals.ToRoman(input);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test, Order(3)]
    public void TestFromRoman_001()
    {
      string input = "I";
      int expected = 1;

      int actual = RomanNumerals.FromRoman(input);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test, Order(4)]
    public void TestFromRoman_002()
    {
      string input = "II";
      int expected = 2;

      int actual = RomanNumerals.FromRoman(input);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test, Order(5)]
    public void TestFromRoman_003()
    {
      string input = "MDCLXVI";
      int expected = 1666;

      int actual = RomanNumerals.FromRoman(input);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test, Order(6)]
    public void TestFromRoman_004()
    {
      string input = "LXXXVI";
      int expected = 86;

      int actual = RomanNumerals.FromRoman(input);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test, Order(7)]
    public void TestFromRoman_005()
    {
      string input = "IV";
      int expected = 4;

      int actual = RomanNumerals.FromRoman(input);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test, Order(7)]
    public void TestToRoman_005()
    {
      int input = 4;
      string expected = "IV";

      string actual = RomanNumerals.ToRoman(input);

      Assert.That(actual, Is.EqualTo(expected));
    }
    

    [Test, Order(8)]
    public void TestToRoman_006()
    {
      int input = 23;
      string expected = "XXIII";

      string actual = RomanNumerals.ToRoman(input);

      Assert.That(actual, Is.EqualTo(expected));
    }
  }
}
