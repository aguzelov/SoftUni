using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Configurations
{
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");

            builder.HasKey(e => e.TeamId);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

            builder.Property(e => e.LogoUrl)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(e => e.Initials)
                .IsRequired(true)
                .HasColumnType("CHAR(3)")
                .IsUnicode(true);

            builder.Property(e => e.Budget)
                .IsRequired(true);

            builder.HasOne(t => t.PrimaryKitColor)
                .WithMany(pc => pc.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.SecondaryKitColor)
                .WithMany(pc => pc.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Town)
                .WithMany(to => to.Teams)
                .HasForeignKey(t => t.TownId);
        }
    }
}