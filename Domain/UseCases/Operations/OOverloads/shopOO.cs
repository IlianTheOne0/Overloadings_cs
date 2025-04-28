namespace ClassLibrary.Shop;
using ClassLibrary.Shop.Interface;
using System.Runtime.CompilerServices;

public partial class Shop
{
    public static Shop operator +(Shop shop, int count)
    {
        shop.area += count;
        return shop;
    }

    public static Shop operator -(Shop shop, int count)
    {
        shop.area -= count;
        return shop;
    }

    public static bool operator ==(Shop? shop0, Shop? shop1)
    {
        if (ReferenceEquals(shop0, shop1)) { return true; }
        if (shop0 is null || shop1 is null) { return false; }
        return false;
    }

    public static bool operator !=(Shop? shop0, Shop? shop1) => !(shop0 == shop1);

    public override bool Equals(object? obj)
    {
        if (obj is Shop otherShop) { return this.area == otherShop.area; }
        return false;
    }

    public override int GetHashCode() { return area.GetHashCode(); }
}