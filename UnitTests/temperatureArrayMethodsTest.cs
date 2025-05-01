using ClassLibrary.TempArray;

namespace UnitTests.TempArray.Methods;

[TestClass]
public class TemperatureArrayMethodsTest
{
    private TemperatureArray _temperatureArray = null!;

    [TestInitialize]
    public void TestInitialize() { _temperatureArray = new TemperatureArray(); }

    [TestMethod]
    public void Add_WhenListNotFull_AddsTemperature()
    {
        int temperature = 20;

        _temperatureArray.add(temperature);

        Assert.AreEqual(1, _temperatureArray.list.Length, "The list length should be 1 after adding a temperature.");
        Assert.AreEqual(temperature, _temperatureArray.list[0], "The first element in the list should match the added temperature.");
    }

    [TestMethod]
    public void Add_WhenListIsFull_ClearsBeforeAdding()
    {
        for (int i = 0; i < 7; i++) { _temperatureArray.add(i); }

        _temperatureArray.add(20);

        Assert.AreEqual(1, _temperatureArray.list.Length, "The list length should be 1 after clearing and adding a new temperature.");
        Assert.AreEqual(20, _temperatureArray.list[0], "The first element in the list should be the newly added temperature after clearing.");
    }

    [TestMethod]
    public void Update_ValidIndex_UpdatesTemperature()
    {
        _temperatureArray.add(10);
        _temperatureArray.update(0, 15);

        Assert.AreEqual(15, _temperatureArray.list[0], "The temperature at index 0 should be updated to the new value.");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Update_InvalidIndex_ThrowsException()
    {
        _temperatureArray.add(10);
        _temperatureArray.update(1, 15);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Update_WhenListIsEmpty_ThrowsException()
    {
        _temperatureArray.clear();
        _temperatureArray.update(0, 10);
    }

    [TestMethod]
    public void Clear_EmptiesTheList()
    {
        _temperatureArray.add(10);
        _temperatureArray.clear();

        Assert.AreEqual(0, _temperatureArray.list.Length, "The list length should be 0 after clearing.");
    }

    [TestMethod]
    public void Avg_WithTemperatures_ReturnsCorrectAverage()
    {
        int[] temps = { 10, 20, 30 };
        foreach (int temp in temps) { _temperatureArray.add(temp); }

        Assert.AreEqual(20, _temperatureArray.avg(), "The average of the temperatures should be correctly calculated.");
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Avg_WhenListIsEmpty_ThrowsException()
    {
        _temperatureArray.clear();
        _temperatureArray.avg();
    }
}
