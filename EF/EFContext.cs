using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day2.EF
{
    public class CartTestContext : DbContext
    {
        public CartTestContext() : base("CartModel")
        {
            Database.SetInitializer<CartTestContext>(new ProductDBInitializer());
        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }        

    }



    //class for hardcode default data
    public class ProductDBInitializer : DropCreateDatabaseAlways<CartTestContext>
    {
        protected override void Seed(CartTestContext context)
        {
            IList<Cart> defaultCartItems = new List<Cart>();
            IList<Order> defaultOrders = new List<Order>();
            IList<OrderItem> defaultOrderItems = new List<OrderItem>();
            IList<Customer> defaultCustomers = new List<Customer>();

            //order items
            defaultOrderItems.Add(new OrderItem() { Name = "Мяч", OrderID = 1 });
            defaultOrderItems.Add(new OrderItem() { Name = "Катана", OrderID = 1 });
            defaultOrderItems.Add(new OrderItem() { Name = "Ручка", OrderID = 1 });
            defaultOrderItems.Add(new OrderItem() { Name = "Слон", OrderID = 1 });
            defaultOrderItems.Add(new OrderItem() { Name = "Iphone", OrderID = 1 });

            //orders
            defaultOrders.Add(new Order() { OrderName = "The First Order", CartID = 1 });

            //carts
            defaultCartItems.Add(new Cart() { CustomerID = 1 });

            //customers
            defaultCustomers.Add(new Customer() { CartID = 1, Name = "lexa" });


            foreach (var cust in defaultCustomers)
                context.Customers.Add(cust);
            foreach (var cart in defaultCartItems)
                context.Carts.Add(cart);
            foreach (var ord in defaultOrders)
                context.Orders.Add(ord);
            foreach (var orderItem in defaultOrderItems)
                context.OrderItems.Add(orderItem);

            base.Seed(context);
        }
    }



}
