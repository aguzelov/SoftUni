using Microsoft.EntityFrameworkCore;
using SIS.Models;

namespace SIS.Data
{
    public class ByTheCakeContext : DbContext
    {
        public ByTheCakeContext() : base()
        {
        }

        public ByTheCakeContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProducts> OrderProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);

            optionsBuilder.UseSqlServer("Server=.;Database=ByTheCake;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}