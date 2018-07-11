using BusTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTickets.Data
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");

            builder.HasKey(e => e.ReviewId);

            builder.Property(e => e.Content)
                .IsRequired(true)
                .IsUnicode(true);

            builder.Property(e => e.PublishingDate)
                .IsRequired(true)
                .HasColumnType("DATETIME");

            builder.HasOne(r => r.Customer)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.CustomerId);

            builder.HasOne(r => r.BusCompany)
                .WithMany(bc => bc.Reviews)
                .HasForeignKey(r => r.BusCompanyId);
        }
    }
}