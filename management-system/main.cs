class Program
{
    static void Main(string[] args)
    {
        // Create products
        var physicalProduct = new PhysicalProduct("Laptop", 999.99m, 50, "Electronics", "Computers");
        var digitalProduct = new DigitalProduct("Software", 29.99m, 100, "Software");

        // Create customers
        var customer1 = new Customer("John", "Doe");
        var customer2 = new Customer("Jane", "Smith");

        // Create discount
        var discount = new PercentageDiscount(10);

        // Create order
        var order1 = new Order(customer1, new List<Product> { physicalProduct }, discount);
        var order2 = new Order(customer2, new List<Product> { digitalProduct }, discount);

        // Create stock manager
        var stockManager = new StockManager();
        stockManager.AddProduct(physicalProduct);
        stockManager.AddProduct(digitalProduct);

        // Simulate orders
        order1.PlaceOrder();
        stockManager.DeductStock(order1._products[0], 30); // Try to buy more than available stock
        order2.PlaceOrder();
        stockManager.DeductStock(order2._products[0], 90); // Buy all available stock

        // Process payment
        var paymentMethod = new CreditCardPayment();
        paymentMethod.ProcessPayment(order1._totalCost);
    }
}
