using DiscountCalculation.Library.Data;
using DiscountCalculation.Library.Enums;
using DiscountCalculation.Library.Interfaces;

namespace DiscountCalculation.Library.Services;
public class DiscountService : IDiscountService
{
    private readonly DbContext _db;

    public DiscountService(DbContext db)
    {
        _db = db;
    }

    public decimal Calculate(string customerName, bool isClubMember, string paymentMethod)
    {
        var customers = _db.Customers();

        bool validCustomer = customers.FirstOrDefault(c => c.Name == customerName) is not null;
        decimal discountValue = 0;

        if (validCustomer is false)
            return discountValue;

        discountValue = paymentMethod switch
        {
            "Debit" => (decimal)DiscountValue.Debit,
            "Credit" => (decimal)DiscountValue.CreditCard,
            _ => 0,
        };

        if (isClubMember)
            return discountValue + (decimal)DiscountValue.IsClubMember;
        else
            return discountValue;
    }
}