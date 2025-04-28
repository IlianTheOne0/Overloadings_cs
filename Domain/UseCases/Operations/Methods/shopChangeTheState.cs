namespace ClassLibrary.Shop;
using ClassLibrary.Shop.Interface;

public partial class Shop
{
    bool IShop.changedTheState() => changeTheState();
    public virtual bool changeTheState() { state = !state; return state; }
}