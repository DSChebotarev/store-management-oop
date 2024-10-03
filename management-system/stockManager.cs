public class StockManager
{
    private List<Product> _products;

    public StockManager()
    {
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void DeductStock(Product product, int quantity)
    {
        if (product.ValidateStock(quantity))
        {
            product.UpdateStock(-quantity);
            Console.WriteLine($"Deducted stock for {product.GetName()}: {quantity}");
            if (product.GetStock() == 0)
            {
                NotifyOutOfStock(product);
            }
        }
        else
        {
            Console.WriteLine($"Not enough stock for {product.GetName()}");
        }
    }

    private void NotifyOutOfStock(Product product)
    {
        Console.WriteLine($"OUT OF STOCK ALERT: {product.GetName()} is out of stock!");
    }
}