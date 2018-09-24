using ByTheCake.Models;
using Microsoft.EntityFrameworkCore;

namespace ByTheCake.Data
{
    public class ByTheCakeContext : DbContext
    {
        public ByTheCakeContext(DbContextOptions options) : base(options)
        {
        }

        public ByTheCakeContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsOrders> ProductsOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            builder.Entity<ProductsOrders>()
                .HasKey(po => new { po.OrderId, po.ProductId });

            builder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithOne(po => po.Product)
                .HasForeignKey(po => po.ProductId);

            builder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithOne(po => po.Order)
                .HasForeignKey(po => po.OrderId);
        }
    }
}