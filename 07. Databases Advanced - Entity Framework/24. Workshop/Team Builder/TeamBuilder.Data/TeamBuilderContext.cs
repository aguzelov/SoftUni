using Microsoft.EntityFrameworkCore;
using TeamBuilder.Data.Config;
using TeamBuilder.Models;

namespace TeamBuilder.Data
{
    public class TeamBuilderContext : DbContext
    {
        public TeamBuilderContext()
        {
        }

        public TeamBuilderContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<TeamEvent> TeamEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new TeamConfig());
            modelBuilder.ApplyConfiguration(new EventConfig());
            modelBuilder.ApplyConfiguration(new InvitationConfig());
            modelBuilder.ApplyConfiguration(new UserTeamConfig());
            modelBuilder.ApplyConfiguration(new TeamEventConfig());
        }
    }
}