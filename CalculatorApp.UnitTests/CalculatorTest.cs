using NUnit.Framework;
using CalculatorApp;
namespace CalculatorApp.UnitTests;

[TestFixture]
public class CalculatorTest
{

    [Test]
    public void TestAdd()
    {
        double num1 = 2;
        double num2 = 3;
        string operation = "add";
        double expected = 5;

        Calculator calc = new Calculator();
        double actual = calc.PerformOperation(num1, num2, operation);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Divide_WhenDividingbyZero_ThrowDividebyZero()
    {
        Calculator calc = new Calculator();
        double num1 = 5;
        double num2 = 0;
        string operation = "divide";

        Assert.Throws<DivideByZeroException>(() => calc.PerformOperation(num1, num2,operation));
    }

    [Test]
    public void Operation_IfOperationIsInvalid_ThrowArgumentException()
    {
        Calculator calc = new Calculator();
        double num1 = 5;
        double num2 = 5;
        string operation = "modulo";

        Assert.Throws<ArgumentException>(() => calc.PerformOperation(num1, num2, operation));
    }
}