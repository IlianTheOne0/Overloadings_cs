namespace UnitTests.Product.UseCases;
using ClassLibrary.Product;

[TestClass]
public sealed class ProductUseCaseTests
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
    public void IsAmountGreater_LeftAmountGreater_ReturnsTrue()
    {
        Product left = new Product("Apple", 1.99f, 5);
        Product right = new Product("Banana", 0.99f, 3);

        bool result = ProductUseCase.isAmountGreater(left, right);

        Assert.IsTrue(result, "Should return true when left amount is greater than right amount");
    }

    [TestMethod]
    public void IsAmountGreater_LeftAmountSmaller_ReturnsFalse()
    {
        Product left = new Product("Apple", 1.99f, 2);
        Product right = new Product("Banana", 0.99f, 5);

        bool result = ProductUseCase.isAmountGreater(left, right);

        Assert.IsFalse(result, "Should return false when left amount is smaller than right amount");
    }

    [TestMethod]
    public void IsAmountGreater_EqualAmounts_ReturnsFalse()
    {
        Product left = new Product("Apple", 1.99f, 5);
        Product right = new Product("Banana", 0.99f, 5);

        bool result = ProductUseCase.isAmountGreater(left, right);

        Assert.IsFalse(result, "Should return false when amounts are equal");
    }

    [TestMethod]
    public void AreAmountsEqual_SameAmounts_ReturnsTrue()
    {
        Product left = new Product("Apple", 1.99f, 5);
        Product right = new Product("Banana", 0.99f, 5);

        bool result = ProductUseCase.areAmountsEqual(left, right);

        Assert.IsTrue(result, "Should return true when amounts are equal");
    }

    [TestMethod]
    public void AreAmountsEqual_DifferentAmounts_ReturnsFalse()
    {
        Product left = new Product("Apple", 1.99f, 5);
        Product right = new Product("Banana", 0.99f, 3);

        bool result = ProductUseCase.areAmountsEqual(left, right);

        Assert.IsFalse(result, "Should return false when amounts are different");
    }
}