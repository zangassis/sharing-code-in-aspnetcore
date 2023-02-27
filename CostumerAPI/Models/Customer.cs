namespace CustomerAPI.Models;
public class Customer
{
    public Customer(string? name, bool isClubMember, string paymentMethod)
    {
        Name = name;
        IsClubMember = isClubMember;
        PaymentMethod = paymentMethod;
    }

    public string? Name { get; set; }
    public bool IsClubMember { get; set; }
    public string? PaymentMethod { get; set; }
}