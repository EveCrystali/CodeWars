using NUnit.Framework;
public class BefungeInterpreterBasicTests
{
    [Test]
    public void Tests()
    {
        string expected = "123456789";
        Assert.That(new BefungeInterpreter().Interpret(">987v>.v\nv456<  :\n>321 ^ _@"), Is.EqualTo(expected));
    }
}
