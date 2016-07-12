using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using day2.EF;


namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            CartTestContext context = new CartTestContext();
            var orderItems = context.OrderItems;

            foreach(var item in orderItems)
            {
                Console.WriteLine($"Order Name:{item.Order.OrderName}, Item name:{item.Name}");
            }
            
            
        }
    }
}
