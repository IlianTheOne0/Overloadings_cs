namespace ClassLibrary.TempArray;

public partial class TemperatureArray
{
    public int this[int id]
    {
        get
        {
            if (id < 0 || id >= 7) { throw new ArgumentOutOfRangeException("Index is out of range. Use 0 (Monday) to 6 (Sunday)."); }
            return list[id];
        }
        set
        {
            if (id < 0 || id >= 7) { throw new ArgumentOutOfRangeException("Index is out of range. Use 0 (Monday) to 6 (Sunday)."); }
            list[id] = value;
        }
    }
}