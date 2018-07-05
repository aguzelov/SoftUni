using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Configurations
{
    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors");

            builder.HasKey(e => e.ColorId);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);

            //builder.HasMany(c => c.PrimaryKitTeams)
            //    .WithOne(t => t.PrimaryKitColor)
            //    .HasForeignKey(c => c.PrimaryKitColorId);

            //builder.HasMany(c => c.SecondaryKitTeams)
            //    .WithOne(t => t.SecondaryKitColor)
            //    .HasForeignKey(c => c.SecondaryKitColorId);
        }
    }
}