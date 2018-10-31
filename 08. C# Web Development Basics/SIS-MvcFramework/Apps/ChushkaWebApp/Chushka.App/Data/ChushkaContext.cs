using Chushka.App.Models;
using Microsoft.EntityFrameworkCore;

namespace Chushka.App.Data
{
    public class ChushkaContext : DbContext
    {
        public ChushkaContext(DbContextOptions options) : base(options)
        {
        }

        public ChushkaContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Chushka;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}