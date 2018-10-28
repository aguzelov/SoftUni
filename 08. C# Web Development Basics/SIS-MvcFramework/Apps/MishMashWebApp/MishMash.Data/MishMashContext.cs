using Microsoft.EntityFrameworkCore;
using MishMash.Models;

namespace MishMash.Data
{
    public class MishMashContext : DbContext
    {
        public MishMashContext()
        {
        }

        public MishMashContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserInChannel> UsersInChannels { get; set; }
        public DbSet<ChannelTag> ChannelTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer("Server=.;Database=MishMash;Integrated Security=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}