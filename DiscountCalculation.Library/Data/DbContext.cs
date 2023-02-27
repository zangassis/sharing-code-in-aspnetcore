using DiscountCalculation.Library.Models;

namespace DiscountCalculation.Library.Data;

public class DbContext
{
    public List<Customer> Customers()
    {
        var customers = new List<Customer>()
        {
            new Customer("Teddy", "teddy@mail.com"),
            new Customer("John", "john@mail.com"),
            new Customer("Maria", "maria@mail.com"),
            new Customer("Sandy", "sandy@mail.com"),
            new Customer("Paul", "poul@mail.com"),
            new Customer("Simone", "simone@mail.com"),
        };

        return customers;
    }
}