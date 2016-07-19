using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryCore.Model
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        //without cascading delete
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
