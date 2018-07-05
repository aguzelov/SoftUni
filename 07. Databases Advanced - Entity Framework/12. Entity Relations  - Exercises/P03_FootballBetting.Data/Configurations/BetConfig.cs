using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Configurations
{
    public class BetConfig : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.ToTable("Bets");

            builder.HasKey(e => e.BetId);

            builder.Property(e => e.Prediction)
                .IsRequired(true)
                .IsUnicode(true);

            builder.Property(e => e.DateTime)
                .HasColumnType("DATETIME2")
                .HasDefaultValue(DateTime.Now);

            builder.Property(e => e.UserId)
                .IsRequired(true);

            builder.Property(e => e.GameId)
                .IsRequired(true);

            builder.HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);

            builder.HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);
        }
    }
}