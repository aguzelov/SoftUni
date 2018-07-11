using BusTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTickets.Data
{
    public class ArrivedTripConfig : IEntityTypeConfiguration<ArrivedTrip>
    {
        public void Configure(EntityTypeBuilder<ArrivedTrip> builder)
        {
            builder.ToTable("ArrivadTrips");

            builder.HasKey(e => e.ArrivedTripId);

            builder.HasOne(a => a.OriginBusStation)
                .WithMany(o => o.OriginTrips)
                .HasForeignKey(a => a.OriginBusStationId);

            builder.HasOne(a => a.DestinationBusStation)
                .WithMany(bs => bs.DestinationTrips)
                .HasForeignKey(a => a.DestinationBusStationId);
        }
    }
}