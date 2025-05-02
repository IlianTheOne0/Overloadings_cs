namespace UnitTests.Fraction;
using ClassLibrary.Fraction;

[TestClass]
public sealed class FractionTests
{
    private Fraction _fraction = null!;

    [TestInitialize]
    public void Initialize() { _fraction = new Fraction(3, 4); }

    [TestMethod]
    public void Test_Constructor_WithDenominatorZero_SetsDenominatorToOne()
    {
        Fraction fraction = new Fraction(5, 0);

        Assert.AreEqual(1, fraction.denominator, "Denominator should be set to 1 when initialized with 0.");
    }

    [TestMethod]
    public void Test_NumeratorSetter_SetsValue()
    {
        _fraction.numerator = 5;

        Assert.AreEqual(5, _fraction.numerator, "Numerator setter did not set the correct value.");
    }

    [TestMethod]
    public void TestdenominatorSetter_SetsValue()
    {
        _fraction.denominator = 3;

        Assert.AreEqual(3, _fraction.denominator, "Denominator setter did not set the correct value.");
    }

    [TestMethod]
    public void TestdenominatorSetter_Zero_SetsToOne()
    {
        _fraction.denominator = 0;

        Assert.AreEqual(1, _fraction.denominator, "Denominator should be set to 1 when assigned a value of 0.");
    }

    [TestMethod]
    public void Test_Simplify_ReducesFraction()
    {
        Fraction fraction = new Fraction(4, 8);

        fraction.simplify();

        Assert.AreEqual(1, fraction.numerator, "Simplify did not reduce the numerator correctly.");
        Assert.AreEqual(2, fraction.denominator, "Simplify did not reduce the denominator correctly.");
    }

    [TestMethod]
    public void Test_Simplify_ReturnsCorrectString()
    {
        Fraction fraction = new Fraction(4, 8);

        string result = fraction.simplify();

        Assert.AreEqual("1 / 2", result, "Simplify did not return the correct string representation.");
    }

    [TestMethod]
    public void Test_getFraction_ReturnsCorrectFormat()
    {
        string result = _fraction.getFraction();

        Assert.AreEqual("3 / 4", result, "getFraction did not return the correct string format.");
    }

    [TestMethod]
    public void Test_CopyConstructor_CopiesValues()
    {
        Fraction copy = new Fraction(_fraction);

        Assert.AreEqual(_fraction.numerator, copy.numerator, "Copy constructor did not copy the numerator correctly.");
        Assert.AreEqual(_fraction.denominator, copy.denominator, "Copy constructor did not copy the denominator correctly.");
    }

    [TestMethod]
    public void Test_Equals_WithSameValues_ReturnsTrue()
    {
        Fraction fraction1 = new Fraction(2, 4);
        Fraction fraction2 = new Fraction(1, 2);

        Assert.IsTrue(fraction1.Equals(fraction2), "Equals did not return true for fractions with the same value.");
    }

    [TestMethod]
    public void Test_Equals_WithDifferentValues_ReturnsFalse()
    {
        Fraction fraction1 = new Fraction(1, 2);
        Fraction fraction2 = new Fraction(1, 3);

        Assert.IsFalse(fraction1.Equals(fraction2), "Equals did not return false for fractions with different values.");
    }
}