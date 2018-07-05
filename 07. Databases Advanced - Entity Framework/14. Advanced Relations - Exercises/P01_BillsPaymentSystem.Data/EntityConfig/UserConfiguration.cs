using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.UserId);

            builder.Property(e => e.FirstName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder.Property(e => e.Email)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(80);

            builder.Property(e => e.Password)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(25);
        }
    }
}