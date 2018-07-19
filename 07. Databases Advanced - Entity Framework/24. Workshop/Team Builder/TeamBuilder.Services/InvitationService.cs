using System.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.Services
{
    public class InvitationService : IInvitationService
    {
        private readonly TeamBuilderContext context;

        public InvitationService(TeamBuilderContext context)
        {
            this.context = context;
        }

        public void AddInvite(User invitedUser, Team teamToInvite)
        {
            Invitation invitation = new Invitation
            {
                InvitedUser = invitedUser,
                Team = teamToInvite,
                IsActive = true
            };

            this.context.Invitations.Add(invitation);

            this.context.SaveChanges();
        }

        public void AcceptInvite(User user, Team team)
        {
            Invitation invitation = this.context.Invitations.First(i => i.Team == team && i.InvitedUser == user);

            invitation.IsActive = false;

            this.context.SaveChanges();
        }

        public void DeclineInvite(User user, Team team)
        {
            Invitation invitation = this.context.Invitations.First(i => i.Team == team && i.InvitedUser == user);

            invitation.IsActive = false;

            this.context.SaveChanges();
        }

        public void Remove(Team team)
        {
            Invitation[] invitation = this.context.Invitations
                .Where(i => i.Team == team)
                .ToArray();

            this.context.Invitations.RemoveRange(invitation);
            this.context.SaveChanges();
        }

        public bool IsInviteExisting(string teamName, User user)
        {
            return this.context.Invitations.Any(i => i.Team.Name == teamName && i.InvitedUser.Username == user.Username && i.IsActive == true);
        }
    }
}