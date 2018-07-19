using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Config
{
    public class UserTeamConfig : IEntityTypeConfiguration<UserTeam>
    {
        public void Configure(EntityTypeBuilder<UserTeam> builder)
        {
            builder.ToTable("UserTeams");

            builder.HasKey(k => new { k.UserId, k.TeamId });

            builder.HasOne(ut => ut.User)
                .WithMany(u => u.Teams)
                .HasForeignKey(ut => ut.UserId);

            builder.HasOne(ut => ut.Team)
                .WithMany(u => u.Users)
                .HasForeignKey(ut => ut.TeamId);
        }
    }
}