namespace DiscountCalculation.Library.Interfaces;

public interface IDiscountService
{
    public decimal Calculate(string customerName, bool isClubMember, string paymentMethod);
}