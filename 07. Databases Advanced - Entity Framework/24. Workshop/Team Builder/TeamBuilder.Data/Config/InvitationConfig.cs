using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Config
{
    public class InvitationConfig : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.ToTable("Invitations");

            builder.HasKey(e => e.Id);

            builder.HasOne(i => i.InvitedUser)
                .WithMany(u => u.ReceivedInvitations)
                .HasForeignKey(i => i.InvitedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Team)
                .WithMany(t => t.SendedInvitations)
                .HasForeignKey(i => i.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}