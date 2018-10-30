using Microsoft.EntityFrameworkCore;
using Torshia.Models;

namespace Torshia.Data
{
    public class TorshiaCotnext : DbContext
    {
        public TorshiaCotnext()
        {
        }

        public TorshiaCotnext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<TaskUsers> TaskUsers { get; set; }
        public DbSet<TaskSectors> TaskSectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer("Server=.;Database=Torshia;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}