namespace UnitTests.Shop.Overloads;
using ClassLibrary.Shop;

[TestClass]
public class shopOverloadsTests
{
    private Shop? _defaultShop;

    [TestInitialize]
    public void Initialize() { _defaultShop = new Shop(10); }

    [TestMethod]
    public void Operator_Addition_WithZero()
    {
        Shop shop = _defaultShop!;

        shop = shop + 0;

        Assert.AreEqual(10, shop.area, "Adding zero should not change the shop's area.");
    }

    [TestMethod]
    public void Operator_Addition_WithNegativeValue()
    {
        Shop shop = _defaultShop!;

        shop = shop + (-5);

        Assert.AreEqual(5, shop.area, "Adding a negative value should decrease the shop's area.");
    }

    [TestMethod]
    public void Operator_Subtraction_WithZero()
    {
        Shop shop = _defaultShop!;

        shop = shop - 0;

        Assert.AreEqual(10, shop.area, "Subtracting zero should not change the shop's area.");
    }

    [TestMethod]
    public void Operator_Subtraction_WithNegativeValue()
    {
        Shop shop = _defaultShop!;

        shop = shop - (-5);

        Assert.AreEqual(15, shop.area, "Subtracting a negative value should increase the shop's area.");
    }

    [TestMethod]
    public void Operator_Equality_WithNull()
    {
        Shop shop1 = _defaultShop!;
        Shop? shop2 = null;

        bool areEqual = shop1 == shop2;

        Assert.IsFalse(areEqual, "A shop instance should not be equal to null.");
    }

    [TestMethod]
    public void Operator_Equality_BothNull()
    {
        Shop? shop1 = null;
        Shop? shop2 = null;

        bool areEqual = shop1 == shop2;

        Assert.IsTrue(areEqual, "Two null shop instances should be considered equal.");
    }

    [TestMethod]
    public void Operator_Inequality_WithNull()
    {
        Shop shop1 = _defaultShop!;
        Shop? shop2 = null;

        bool areNotEqual = shop1 != shop2;

        Assert.IsTrue(areNotEqual, "A shop instance should not be considered equal to null.");
    }

    [TestMethod]
    public void Operator_Inequality_BothNull()
    {
        Shop? shop1 = null;
        Shop? shop2 = null;

        bool areNotEqual = shop1 != shop2;

        Assert.IsFalse(areNotEqual, "Two null shop instances should not be considered unequal.");
    }

    [TestMethod]
    public void Operator_Equality_TwoDifferentInstances()
    {
        Shop shop1 = _defaultShop!;
        Shop shop2 = new Shop(10);

        bool areEqual = shop1 == shop2;

        Assert.IsFalse(areEqual, "Two different shop instances with the same area should not be considered equal.");
    }

    [TestMethod]
    public void Operator_Inequality_TwoDifferentInstances()
    {
        Shop shop1 = _defaultShop!;
        Shop shop2 = new Shop(10);

        bool areNotEqual = shop1 != shop2;

        Assert.IsTrue(areNotEqual, "Two different shop instances with the same area should be considered unequal.");
    }
}