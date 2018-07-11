using BusTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTickets.Data
{
    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.ToTable("BankAccounts");

            builder.HasKey(e => e.BankAccountId);

            builder.Property(e => e.AccountNumber)
                .IsRequired(true)
                .HasMaxLength(20);

            builder.HasOne(ba => ba.Customer)
                .WithOne(c => c.BankAccount)
                .HasForeignKey<BankAccount>(ba => ba.CustomerId);
        }
    }
}