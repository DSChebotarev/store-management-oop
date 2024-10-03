public interface IDiscount
{
    decimal ApplyDiscount(decimal price);
}

public class FixedDiscount : IDiscount
{
    private readonly decimal _discountAmount;

    public FixedDiscount(decimal discountAmount)
    {
        _discountAmount = discountAmount;
    }

    public decimal ApplyDiscount(decimal price)
    {
        return price - _discountAmount;
    }
}

public class PercentageDiscount : IDiscount
{
    private readonly decimal _discountPercentage;

    public PercentageDiscount(decimal discountPercentage)
    {
        _discountPercentage = discountPercentage / 100;
    }

    public decimal ApplyDiscount(decimal price)
    {
        return price * (1 - _discountPercentage);
    }
}

public class Order
{
    private readonly Customer _customer;
    private readonly List<Product> _products;
    private readonly IDiscount _discount;
    private decimal _totalCost;

    public Order(Customer customer, List<Product> products, IDiscount discount)
    {
        _customer = customer;
        _products = products;
        _discount = discount;
        _totalCost = CalculateTotalCost();
    }

    private decimal CalculateTotalCost()
    {
        decimal total = 0;
        foreach (var product in _products)
        {
            total += product.GetPrice();
        }
        return _discount.ApplyDiscount(total);
    }

    public void PlaceOrder()
    {
        Console.WriteLine($"Placing order for {_customer.FirstName} {_customer.LastName}");
        Console.WriteLine("Order details:");
        foreach (var product in _products)
        {
            product.DisplayDetails();
        }
        Console.WriteLine($"Total cost: ${_totalCost:F2}");
        Console.WriteLine($"Applying discount: {(_discount is FixedDiscount ? "Fixed" : "Percentage")} discount of {(decimal)((IDiscount)_discount).ApplyDiscount(100):F2}%");
        Console.WriteLine($"Final cost: ${_totalCost:F2}");
        Console.WriteLine();
    }
}