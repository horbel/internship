using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryCore.Model
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public int ID { get; set; }
        public int Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
