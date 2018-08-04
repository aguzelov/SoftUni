using Instagraph.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagraph.Data
{
    public class InstagraphContext : DbContext
    {
        public InstagraphContext()
        {
        }

        public InstagraphContext(DbContextOptions options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserFollower> UsersFollowers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasAlternateKey(u => u.Username);

            builder.Entity<User>()
                .HasOne(u => u.ProfilePicture)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.ProfilePictureId);

            builder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasOne(p => p.Picture)
                .WithMany(pic => pic.Posts)
                .HasForeignKey(p => p.PictureId);

            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.PostId);

            builder.Entity<UserFollower>()
                .HasKey(e => new { e.UserId, e.FollowerId });

            builder.Entity<UserFollower>()
                .HasOne(uf => uf.Follower)
                .WithMany(u => u.UsersFollowing)
                .HasForeignKey(uf => uf.FollowerId);

            builder.Entity<UserFollower>()
                .HasOne(uf => uf.User)
                .WithMany(u => u.Followers)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}