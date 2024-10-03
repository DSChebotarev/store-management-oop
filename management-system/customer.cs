public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Customer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Customer Information:\nFirst Name: {FirstName}\nLast Name: {LastName}\n");
    }
}