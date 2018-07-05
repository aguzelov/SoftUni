using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethods");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new { e.UserId, e.BankAccountId, e.CreditCardId })
                .IsUnique(true);

            builder.HasOne(pm => pm.BankAccount)
                .WithOne(ba => ba.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.BankAccountId);

            builder.HasOne(pm => pm.CreditCard)
                .WithOne(cc => cc.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.CreditCardId);

            builder.HasOne(pm => pm.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(pm => pm.UserId);
        }
    }
}