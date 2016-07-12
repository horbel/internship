namespace day2.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CartModel : DbContext
    {
        public CartModel()
            : base("name=CartModel")
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderName)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderItem>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
