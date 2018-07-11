using BusTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTickets.Data
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(e => e.CustomerId);

            builder.Property(e => e.FirstName)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.FirstName)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.DateOfBirth)
                .IsRequired(true)
                .HasColumnType("DATETIME2");

            builder.HasOne(c => c.HomeTown)
                .WithMany(t => t.Customers)
                .HasForeignKey(c => c.HomeTownId);
        }
    }
}