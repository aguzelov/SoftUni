using BusTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTickets.Data
{
    public class BusTicketsContext : DbContext
    {
        public BusTicketsContext()
        {
        }

        public BusTicketsContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<BusStation> BusStations { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<BusCompany> BusCompanies { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<ArrivedTrip> ArrivedTrips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TownConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new BusStationConfig());
            modelBuilder.ApplyConfiguration(new BankAccountConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());
            modelBuilder.ApplyConfiguration(new BusCompanyConfig());
            modelBuilder.ApplyConfiguration(new TripConfig());
            modelBuilder.ApplyConfiguration(new TicketConfig());
            modelBuilder.ApplyConfiguration(new ArrivedTripConfig());
        }
    }
}