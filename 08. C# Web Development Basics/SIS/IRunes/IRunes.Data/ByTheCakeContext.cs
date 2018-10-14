using Microsoft.EntityFrameworkCore;
using SIS.App.IRunes.Models;

namespace SIS.App.IRunes.Data
{
    public class IRunesContext : DbContext
    {
        public IRunesContext() : base()
        {
        }

        public IRunesContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);

            optionsBuilder.UseSqlServer("Server=.;Database=IRunes;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}