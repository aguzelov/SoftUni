using BusTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTickets.Data
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("Trips");

            builder.HasKey(e => e.TripId);

            builder.Property(e => e.DepartureTime)
                .IsRequired(true)
                .HasColumnType("DATETIME2");

            builder.Property(e => e.ArrivalTime)
                .IsRequired(true)
                .HasColumnType("DATETIME2");

            builder.HasOne(t => t.OriginBusStation)
                .WithMany(bs => bs.DepartedTrips)
                .HasForeignKey(t => t.OriginBusStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.DestinationBusStation)
                .WithMany(bs => bs.ArrivedTrips)
                .HasForeignKey(t => t.DestinationBusStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.BusCompany)
                .WithMany(bc => bc.Trips)
                .HasForeignKey(t => t.BusCompanyId);
        }
    }
}