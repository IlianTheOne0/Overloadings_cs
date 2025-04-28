namespace UnitTests.Shop.Methods;
using ClassLibrary.Shop;

[TestClass]
public class ShopTests
{
    [TestMethod]
    public void ChangeTheState_TogglesStateCorrectly()
    {
        Shop shop = new Shop();
        bool initialState = shop.state;

        bool newState = shop.changeTheState();

        Assert.AreNotEqual(initialState, newState, "The state should be toggled.");
        Assert.AreEqual(newState, shop.state, "The returned state should match the updated state.");
    }
}