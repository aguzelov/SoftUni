using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Config
{
    public class TeamEventConfig : IEntityTypeConfiguration<TeamEvent>
    {
        public void Configure(EntityTypeBuilder<TeamEvent> builder)
        {
            builder.ToTable("TeamEvents");

            builder.HasKey(k => new { k.TeamId, k.EventId });

            builder.HasOne(te => te.Team)
                .WithMany(t => t.Events)
                .HasForeignKey(te => te.TeamId);

            builder.HasOne(te => te.Event)
               .WithMany(t => t.Teams)
               .HasForeignKey(te => te.EventId);
        }
    }
}