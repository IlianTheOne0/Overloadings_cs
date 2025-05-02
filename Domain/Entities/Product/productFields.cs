namespace ClassLibrary.Product;

public partial struct Product
{
    public int id { get; set; }
    private static int _idCounter = 0;
    private string _name;
    private float _price;
    private int _amount;
    public string name { get => _name; set => _name = (String.IsNullOrEmpty(value)) ? "Unknown" : value; }
    public float price { get => _price; set => _price = (value > 0) ? value : 0.0f; }
    public int amount { get => _amount; set => _amount = (value > 0) ? value : 0; }
}