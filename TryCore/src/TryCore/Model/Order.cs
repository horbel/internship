using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryCore.Model
{
    public class Order
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }

        public int? ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
