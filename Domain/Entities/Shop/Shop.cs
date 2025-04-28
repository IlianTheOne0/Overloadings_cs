namespace ClassLibrary.Shop;
using ClassLibrary.Shop.Interface;

public partial class Shop : IShop
{
    public bool state { get; private set; }
    public int area { get; private set; }

    public Shop() { this.area = 0; }
    public Shop(int area) {  this.area = area; }
}