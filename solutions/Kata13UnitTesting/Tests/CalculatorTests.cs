using NUnit.Framework;

namespace Kata13UnitTesting.Tests;

public class CalculatorTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Add_WhenCalledWithTwoIntegers_ReturnsTheirSum()
    {
        var calculator = new Calculator();
        var result = calculator.Add(2, 3);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Subtract_WhenCalledWithTwoIntegers_ReturnsTheirDifference()
    {
        var calculator = new Calculator();
        var result = calculator.Subtract(5, 3);
        Assert.That(result, Is.EqualTo(2));
    }

}