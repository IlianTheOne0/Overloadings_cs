namespace UnitTests.Product.Overloads;
using ClassLibrary.Product;

[TestClass]
public sealed class ProductOperatorTests
{
    [TestInitialize]
    public void Initialize()
    {
        Type productType = typeof(Product);
        var idCounterField = productType.GetField("_idCounter", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
            ?? throw new KeyNotFoundException("The static field \"_idCounter\" was not found in the specified type.");
        idCounterField.SetValue(null, 0);
    }

    [TestMethod]
    public void Addition_WithPositiveValue_IncreasesAmount()
    {
        Product product = new Product("Apple", 1.99f, 5);
        Product result = product + 3;
        Assert.AreEqual(8, result.amount, "Amount should increase by added value");
    }

    [TestMethod]
    public void Addition_WithNegativeValue_ClampsToZero()
    {
        Product product = new Product("Banana", 0.99f, 2);
        Product result = product + (-5);
        Assert.AreEqual(0, result.amount, "Amount should clamp to zero when result is negative");
    }

    [TestMethod]
    public void Subtraction_WithPositiveValue_DecreasesAmount()
    {
        Product product = new Product("Cherry", 2.49f, 10);
        Product result = product - 4;
        Assert.AreEqual(6, result.amount, "Amount should decrease by subtracted value");
    }

    [TestMethod]
    public void Subtraction_ResultNegative_ClampsToZero()
    {
        Product product = new Product("Date", 3.99f, 3);
        Product result = product - 5;
        Assert.AreEqual(0, result.amount, "Amount should clamp to zero when result is negative");
    }

    [TestMethod]
    public void EqualityOperator_IdenticalProducts_ReturnsTrue()
    {
        Product product1 = new Product("Apple", 1.99f, 5);
        Product product2 = product1;
        Assert.IsTrue(product1 == product2, "Should return true for same instance");
    }

    [TestMethod]
    public void EqualityOperator_DifferentIds_ReturnsFalse()
    {
        Product product1 = new Product("Apple", 1.99f, 5);
        Product product2 = new Product("Apple", 1.99f, 5);
        Assert.IsFalse(product1 == product2, "Should return false when IDs differ");
    }

    [TestMethod]
    public void InequalityOperator_DifferentProducts_ReturnsTrue()
    {
        Product product1 = new Product("Apple", 1.99f, 5);
        Product product2 = new Product("Banana", 0.99f, 3);
        Assert.IsTrue(product1 != product2, "Should return true for different products");
    }

    [TestMethod]
    public void GreaterThanOperator_LeftGreater_ReturnsTrue()
    {
        Product left = new Product("Apple", 1.99f, 5);
        Product right = new Product("Banana", 0.99f, 3);
        Assert.IsTrue(left > right, "Should return true when left amount is greater");
    }

    [TestMethod]
    public void LessThanOperator_LeftSmaller_ReturnsTrue()
    {
        Product left = new Product("Apple", 1.99f, 2);
        Product right = new Product("Banana", 0.99f, 5);
        Assert.IsTrue(left < right, "Should return true when left amount is smaller");
    }

    [TestMethod]
    public void Equals_WithSameReference_ReturnsTrue()
    {
        Product product = new Product("Apple", 1.99f, 5);
        Assert.IsTrue(product.Equals(product), "Should return true for same reference");
    }

    [TestMethod]
    public void Equals_WithDifferentType_ReturnsFalse()
    {
        Product product = new Product("Apple", 1.99f, 5);
        Assert.IsFalse(product.Equals(new object()), "Should return false for different type");
    }

    [TestMethod]
    public void GetHashCode_EqualObjects_MatchesWhenForcedEqual()
    {
        Product product1 = new Product("Apple", 1.99f, 5);
        Product product2 = new Product("Apple", 1.99f, 5);

        product2.id = product1.id;

        Assert.AreEqual(product1.GetHashCode(), product2.GetHashCode(), "Hash codes should match when IDs are equal");
    }
}