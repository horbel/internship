using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryCore.Model
{
    public class ProductContext : DbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Category> Categories { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) :
            base(options)
        {
        }
    }
}
