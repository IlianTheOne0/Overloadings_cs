namespace UnitTests.Fraction.Methods;
using ClassLibrary.Fraction;

[TestClass]
public sealed class FractionStaticMethodsTests
{
    [TestMethod]
    public void Test_Add_TwoFractions_ReturnsSum()
    {
        Fraction left = new Fraction(1, 2);
        Fraction right = new Fraction(1, 2);

        Fraction result = (Fraction)Fraction.add(left, right);

        Assert.AreEqual(4, ((Fraction)result).numerator, "The numerator of the sum is incorrect.");
        Assert.AreEqual(4, ((Fraction)result).denominator, "The denominator of the sum is incorrect.");
    }

    [TestMethod]
    public void Test_Subtract_TwoFractions_ReturnsDifference()
    {
        Fraction left = new Fraction(3, 4);
        Fraction right = new Fraction(1, 4);

        Fraction result = (Fraction)Fraction.subtract(left, right);

        Assert.AreEqual(8, ((Fraction)result).numerator, "The numerator of the difference is incorrect.");
        Assert.AreEqual(16, ((Fraction)result).denominator, "The denominator of the difference is incorrect.");
    }

    [TestMethod]
    public void Test_Multiply_TwoFractions_ReturnsProduct()
    {
        Fraction left = new Fraction(2, 3);
        Fraction right = new Fraction(3, 4);

        Fraction result = (Fraction)Fraction.multiply(left, right);

        Assert.AreEqual(6, ((Fraction)result).numerator, "The numerator of the product is incorrect.");
        Assert.AreEqual(12, ((Fraction)result).denominator, "The denominator of the product is incorrect.");
    }

    [TestMethod]
    public void Test_Divide_TwoFractions_ReturnsQuotient()
    {
        Fraction left = new Fraction(2, 3);
        Fraction right = new Fraction(3, 4);

        Fraction result = (Fraction)Fraction.divide(left, right);

        Assert.AreEqual(8, ((Fraction)result).numerator, "The numerator of the quotient is incorrect.");
        Assert.AreEqual(9, ((Fraction)result).denominator, "The denominator of the quotient is incorrect.");
    }

    [TestMethod]
    public void Test_CompareTo_LeftGreaterThanRight_ReturnsPositive()
    {
        Fraction left = new Fraction(3, 1);
        Fraction right = new Fraction(2, 1);

        int result = Fraction.compareTo(left, right);

        Assert.IsTrue(result > 0, "Expected a positive value when the left fraction is greater than the right.");
    }

    [TestMethod]
    public void Test_CompareTo_LeftLessThanRight_ReturnsNegative()
    {
        Fraction left = new Fraction(1, 1);
        Fraction right = new Fraction(2, 1);

        int result = Fraction.compareTo(left, right);

        Assert.IsTrue(result < 0, "Expected a negative value when the left fraction is less than the right.");
    }

    [TestMethod]
    public void Test_CompareTo_EqualValues_ReturnsZero()
    {
        Fraction left = new Fraction(1, 2);
        Fraction right = new Fraction(3, 4);

        int result = Fraction.compareTo(left, right);

        Assert.AreEqual(0, result, "Expected a zero value when the fractions are equal.");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_Add_LeftIsNull_ThrowsArgumentNullException()
    {
        Fraction.add(null!, new Fraction(1, 2));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_Subtract_RightIsNull_ThrowsArgumentNullException()
    {
        Fraction.subtract(new Fraction(1, 2), null!);
    }

    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public void Test_Divide_ByZeroNumerator_ThrowsException()
    {
        Fraction left = new Fraction(1, 2);
        Fraction right = new Fraction(0, 1);

        Fraction.divide(left, right);
    }
}