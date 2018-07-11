using BusTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTickets.Data
{
    public class BusCompanyConfig : IEntityTypeConfiguration<BusCompany>
    {
        public void Configure(EntityTypeBuilder<BusCompany> builder)
        {
            builder.ToTable("BusCompanies");

            builder.HasKey(e => e.BusCompanyId);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(e => e.Nationality)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);
        }
    }
}