using System;
namespace customerservice.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
    }

    public class Customers : List<Customer>
    {
        public Customers()
        {
            Add(new Customer() { CustomerId=101, CustomerName="C1"});
            Add(new Customer() { CustomerId = 102, CustomerName = "C2" });
            Add(new Customer() { CustomerId = 103, CustomerName = "C3" });
            Add(new Customer() { CustomerId = 104, CustomerName = "C4" });
            Add(new Customer() { CustomerId = 105, CustomerName = "C5" });
        }
    }
}

