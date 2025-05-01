namespace ClassLibrary.TempArray;

public partial class TemperatureArray
{
    public void add(int degrees)
    {
        if (list.Length >= 7) { clear(); }
        list = list.Append(degrees).ToArray();
    }

    public void update(int id, int degrees)
    {
        if (id < 0 || id >= list.Length) { throw new ArgumentOutOfRangeException("The id must be within the valid range of the list."); }
        list[id] = degrees;
    }

    public void clear() => list = new int[0];

    public int avg() => list.Length == 0 ? throw new InvalidOperationException("The list is empty.") : (int)list.Average();
}