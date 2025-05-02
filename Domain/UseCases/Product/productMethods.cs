namespace ClassLibrary.Product;

public partial class ProductUseCase
{
    public static bool isAmountGreater(Product left, Product right) => left.amount > right.amount;
    public static bool areAmountsEqual(Product left, Product right) => left.amount == right.amount;
}