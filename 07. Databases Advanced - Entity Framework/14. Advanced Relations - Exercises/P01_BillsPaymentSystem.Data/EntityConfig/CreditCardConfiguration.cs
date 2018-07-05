using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.ToTable("CreditCards");

            builder.HasKey(e => e.CreditCardId);

            builder.Property(e => e.Limit)
                .IsRequired(true);

            builder.Property(e => e.MoneyOwed)
                .IsRequired(true);

            builder.Ignore("LimitLeft");

            builder.Property(e => e.ExpirationDate)
                .IsRequired(true)
                .HasColumnType("DATETIME2");
        }
    }
}