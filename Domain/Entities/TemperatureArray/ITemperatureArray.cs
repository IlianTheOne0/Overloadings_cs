namespace ClassLibrary.TempArray.Interface;

public interface ITemperatureArray
{
    void add(int degrees);
    void update(int id, int degrees);
    void clear();
    int avg();
}