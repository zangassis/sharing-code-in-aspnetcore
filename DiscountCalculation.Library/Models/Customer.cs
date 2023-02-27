namespace DiscountCalculation.Library.Models;
public class Customer
{
    public Customer(string? name, string? email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }

    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}

