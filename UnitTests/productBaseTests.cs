namespace UnitTests.Product.Base;
using ClassLibrary.Product;

[TestClass]
public sealed class ProductTests
{
    [TestInitialize]
    public void Initialize()
    {
        Type productType = typeof(Product);
        var idCounterField = productType.GetField("_idCounter", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
            ?? throw new KeyNotFoundException("The static field \"_idCounter\" was not found in the specified type.");
        idCounterField?.SetValue(null, 0);
    }

    [TestMethod]
    public void Constructor_WithValidParameters_SetsFieldsCorrectly()
    {
        Product product = new Product("Apple", 1.99f, 5);

        Assert.AreEqual(1, product.id, "The product ID was not set correctly.");
        Assert.AreEqual("Apple", product.name, "The product name was not set correctly.");
        Assert.AreEqual(1.99f, product.price, "The product price was not set correctly.");
        Assert.AreEqual(5, product.amount, "The product amount was not set correctly.");
    }

    [TestMethod]
    public void CopyConstructor_CopiesFieldsExceptId()
    {
        Product original = new Product("Banana", 0.99f, 10);
        Product copy = new Product(original);

        Assert.AreEqual(2, copy.id, "The copied product ID was not incremented correctly.");
        Assert.AreEqual(original.name, copy.name, "The copied product name does not match the original.");
        Assert.AreEqual(original.price, copy.price, "The copied product price does not match the original.");
        Assert.AreEqual(original.amount, copy.amount, "The copied product amount does not match the original.");
    }

    [TestMethod]
    public void Name_WhenEmpty_SetsToUnknown()
    {
        Product product = new Product("", 2.5f, 3);

        Assert.AreEqual("Unknown", product.name, "The product name was not set to 'Unknown' when empty.");
    }

    [TestMethod]
    public void Price_WhenNegative_SetsToZero()
    {
        Product product = new Product("Cherry", -4.0f, 2);

        Assert.AreEqual(0.0f, product.price, "The product price was not set to 0 when negative.");
    }

    [TestMethod]
    public void Amount_WhenNegative_SetsToZero()
    {
        Product product = new Product("Date", 3.5f, -1);

        Assert.AreEqual(0, product.amount, "The product amount was not set to 0 when negative.");
    }
}