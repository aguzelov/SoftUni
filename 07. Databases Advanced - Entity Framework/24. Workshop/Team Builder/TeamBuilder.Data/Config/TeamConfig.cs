using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Config
{
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Name)
                .IsUnique(true);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(25);

            builder.Property(e => e.Description)
                .HasMaxLength(32);

            builder.Property(e => e.Acronym)
                .IsRequired(true)
                .HasColumnType("CHAR(3)");

            builder.HasOne(t => t.Creator)
                .WithMany(u => u.CreatedTeams)
                .HasForeignKey(t => t.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}