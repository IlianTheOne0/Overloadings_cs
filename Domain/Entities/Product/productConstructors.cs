namespace ClassLibrary.Product;

public partial struct Product
{
    public Product(string name, float price, int amount)
    {
        id = ++_idCounter;
        this.name = name;
        this.price = price;
        this.amount = amount;
    }

    public Product(Product product)
    {
        id = ++_idCounter;
        name = product.name;
        price = product.price;
        amount = product.amount;
    }
}
