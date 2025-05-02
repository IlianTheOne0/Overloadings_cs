namespace ClassLibrary.Product;

public partial struct Product
{
    public static Product operator +(Product product, int value) => new(product.name, product.price, product.amount + value);

    public static Product operator -(Product product, int value) => new(product.name, product.price, product.amount - value);

    public static bool operator ==(Product left, Product right) => left.Equals(right);
    public static bool operator !=(Product left, Product right) => !(left == right);

    public static bool operator >(Product left, Product right) => left.amount > right.amount;
    public static bool operator <(Product left, Product right) => left.amount < right.amount;

    public override bool Equals(object? obj) =>
        obj is Product other &&
            id == other.id &&
            name == other.name &&
            price.Equals(other.price) &&
            amount == other.amount;

    public override int GetHashCode() => HashCode.Combine(id, name, price, amount);
}