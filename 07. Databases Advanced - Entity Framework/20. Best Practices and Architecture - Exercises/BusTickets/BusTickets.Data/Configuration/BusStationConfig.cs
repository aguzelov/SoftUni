using BusTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTickets.Data
{
    public class BusStationConfig : IEntityTypeConfiguration<BusStation>
    {
        public void Configure(EntityTypeBuilder<BusStation> builder)
        {
            builder.ToTable("BusStations");

            builder.HasKey(e => e.BusStationId);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(150)
                .IsUnicode(true);

            builder.HasOne(bs => bs.Town)
                .WithMany(t => t.BusStations)
                .HasForeignKey(bs => bs.TownId);
        }
    }
}