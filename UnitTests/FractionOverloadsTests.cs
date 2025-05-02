namespace UnitTests.Fraction.Overloads;
using ClassLibrary.Fraction;

[TestClass]
public sealed class FractionOverloadsTests
{
    [TestMethod]
    public void Test_AdditionOperator_AddsFractions()
    {
        Fraction left = new Fraction(1, 2);
        Fraction right = new Fraction(1, 2);

        Fraction result = (Fraction)(left + right);

        Assert.AreEqual(4, ((Fraction)result).numerator, "The numerator of the result is incorrect after addition.");
        Assert.AreEqual(4, ((Fraction)result).denominator, "The denominator of the result is incorrect after addition.");
    }

    [TestMethod]
    public void Test_SubtractionOperator_SubtractsFractions()
    {
        Fraction left = new Fraction(3, 4);
        Fraction right = new Fraction(1, 4);

        Fraction result = (Fraction)(left - right);

        Assert.AreEqual(8, ((Fraction)result).numerator, "The numerator of the result is incorrect after subtraction.");
        Assert.AreEqual(16, ((Fraction)result).denominator, "The denominator of the result is incorrect after subtraction.");
    }

    [TestMethod]
    public void Test_MultiplicationOperator_MultipliesFractions()
    {
        Fraction left = new Fraction(2, 3);
        Fraction right = new Fraction(3, 4);

        Fraction result = (Fraction)(left * right);

        Assert.AreEqual(6, ((Fraction)result).numerator, "The numerator of the result is incorrect after multiplication.");
        Assert.AreEqual(12, ((Fraction)result).denominator, "The denominator of the result is incorrect after multiplication.");
    }

    [TestMethod]
    public void Test_DivisionOperator_DividesFractions()
    {
        Fraction left = new Fraction(2, 3);
        Fraction right = new Fraction(3, 4);

        Fraction result = (Fraction)(left / right);

        Assert.AreEqual(8, ((Fraction)result).numerator, "The numerator of the result is incorrect after division.");
        Assert.AreEqual(9, ((Fraction)result).denominator, "The denominator of the result is incorrect after division.");
    }

    [TestMethod]
    public void Test_EqualityOperator_EqualFractions_ReturnsTrue()
    {
        Fraction left = new Fraction(2, 4);
        Fraction right = new Fraction(1, 2);

        Assert.IsTrue(left == right, "Equality operator failed for equal fractions.");
    }

    [TestMethod]
    public void Test_EqualityOperator_UnequalFractions_ReturnsFalse()
    {
        Fraction left = new Fraction(1, 2);
        Fraction right = new Fraction(1, 3);

        Assert.IsFalse(left == right, "Equality operator failed for unequal fractions.");
    }

    [TestMethod]
    public void Test_EqualityOperator_LeftNull_ReturnsFalse()
    {
        Fraction left = null;
        Fraction right = new Fraction(1, 2);

        Assert.IsFalse(left == right, "Equality operator failed when the left fraction is null.");
    }

    [TestMethod]
    public void Test_EqualityOperator_BothNull_ReturnsTrue()
    {
        Fraction left = null;
        Fraction right = null;

        Assert.IsTrue(left == right, "Equality operator failed when both fractions are null.");
    }

    [TestMethod]
    public void Test_InequalityOperator_UnequalFractions_ReturnsTrue()
    {
        Fraction left = new Fraction(1, 2);
        Fraction right = new Fraction(1, 3);

        Assert.IsTrue(left != right, "Inequality operator failed for unequal fractions.");
    }

    [TestMethod]
    public void Test_InequalityOperator_EqualFractions_ReturnsFalse()
    {
        Fraction left = new Fraction(2, 4);
        Fraction right = new Fraction(1, 2);

        Assert.IsFalse(left != right, "Inequality operator failed for equal fractions.");
    }

    [TestMethod]
    public void Test_InequalityOperator_OneNull_ReturnsTrue()
    {
        Fraction left = null;
        Fraction right = new Fraction(1, 2);

        Assert.IsTrue(left != right, "Inequality operator failed when one fraction is null.");
    }
}