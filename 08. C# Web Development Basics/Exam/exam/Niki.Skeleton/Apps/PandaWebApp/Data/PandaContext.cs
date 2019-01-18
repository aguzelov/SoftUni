using Microsoft.EntityFrameworkCore;
using PandaWebApp.Models;

namespace PandaWebApp.Data
{
    public class PandaContext : DbContext
    {
        public PandaContext(DbContextOptions options) : base(options)
        {
        }

        public PandaContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Server=.;Database=Panda;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>()
            .HasOne(r => r.Recipient)
            .WithMany(u => u.Receipts)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Package>()
            .HasOne(p => p.Recipient)
            .WithMany(u => u.Packages)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}