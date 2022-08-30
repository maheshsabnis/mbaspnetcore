using System;
namespace ordersservice.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public int CustomerId { get; set; }
    }


    public class Orders : List<Order>
    {
        public Orders()
        {
            Add(new Order() {OrderId=1,OrderName="O1",CustomerId=101 });
            Add(new Order() { OrderId = 2, OrderName = "O2", CustomerId = 101 });
            Add(new Order() { OrderId = 3, OrderName = "O3", CustomerId = 102 });
            Add(new Order() { OrderId = 4, OrderName = "O4", CustomerId = 102 });
            Add(new Order() { OrderId = 5, OrderName = "O5", CustomerId = 103 });
            Add(new Order() { OrderId = 6, OrderName = "O6", CustomerId = 103 });
            Add(new Order() { OrderId = 6, OrderName = "O7", CustomerId = 104 });
            Add(new Order() { OrderId = 8, OrderName = "O8", CustomerId = 104 });
            Add(new Order() { OrderId = 9, OrderName = "O9", CustomerId = 105 });
            Add(new Order() { OrderId = 10, OrderName = "O10", CustomerId = 105 });
        }
    }
}

