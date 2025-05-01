using ClassLibrary.TempArray;

namespace UnitTests.TempArray.Overloads;

[TestClass]
public class TemperatureArrayOverloadsTest
{
    private TemperatureArray _temperatureArray = null!;

    [TestInitialize]
    public void TestInitialize() { _temperatureArray = new TemperatureArray(); }

    [TestMethod]
    public void Indexer_ValidIndex_GetReturnsValue()
    {
        _temperatureArray[0] = 10;

        Assert.AreEqual(10, _temperatureArray[0], "The value retrieved from the indexer should match the value set.");
    }

    [TestMethod]
    public void Indexer_ValidIndex_SetUpdatesValue()
    {
        _temperatureArray[3] = 15;

        Assert.AreEqual(15, _temperatureArray[3], "The value at the specified index should be updated correctly.");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Indexer_InvalidIndex_GetThrowsException()
    {
        int temp = _temperatureArray[7];
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Indexer_InvalidIndex_SetThrowsException()
    {
        _temperatureArray[-1] = 20;
    }

    [TestMethod]
    public void Indexer_AllDaysAccessible()
    {
        for (int i = 0; i < 7; i++)
        {
            _temperatureArray[i] = i * 5;

            Assert.AreEqual(i * 5, _temperatureArray[i], $"The value at index {i} should match the value set ({i * 5}).");
        }
    }
}