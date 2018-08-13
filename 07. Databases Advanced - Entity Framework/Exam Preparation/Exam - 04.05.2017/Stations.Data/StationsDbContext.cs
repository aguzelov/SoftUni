using Microsoft.EntityFrameworkCore;
using Stations.Models;

namespace Stations.Data
{
    public class StationsDbContext : DbContext
    {
        public StationsDbContext()
        {
        }

        public StationsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<SeatingClass> SeatingClasses { get; set; }
        public DbSet<TrainSeat> TrainSeats { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<CustomerCard> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Station>()
                .HasAlternateKey(e => e.Name);

            builder.Entity<Train>()
                .HasAlternateKey(e => e.TrainNumber);

            builder.Entity<SeatingClass>()
                .HasAlternateKey(sc => new { sc.Name, sc.Abbreviation });

            builder.Entity<SeatingClass>()
                .HasAlternateKey(e => e.Abbreviation);

            builder.Entity<TrainSeat>()
                .HasOne(ts => ts.Train)
                .WithMany(t => t.TrainSeats)
                .HasForeignKey(ts => ts.TrainId);

            builder.Entity<TrainSeat>()
                .HasOne(ts => ts.SeatingClass)
                .WithMany(t => t.TrainSeats)
                .HasForeignKey(ts => ts.SeatingClassId);

            builder.Entity<Trip>()
                .HasOne(t => t.OriginStation)
                .WithMany(s => s.TripsFrom)
                .HasForeignKey(t => t.OriginStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Trip>()
                .HasOne(t => t.DestinationStation)
                .WithMany(s => s.TripsTo)
                .HasForeignKey(t => t.DestinationStationId);

            builder.Entity<Trip>()
                .HasOne(t => t.Train)
                .WithMany(s => s.Trips)
                .HasForeignKey(t => t.TrainId);

            builder.Entity<Ticket>()
                .HasOne(t => t.Trip)
                .WithMany(t => t.Tickets)
                .HasForeignKey(t => t.TripId);

            builder.Entity<Ticket>()
                .HasOne(t => t.CustomerCard)
                .WithMany(t => t.BoughtTickets)
                .HasForeignKey(t => t.CustomerCardId);
        }
    }
}