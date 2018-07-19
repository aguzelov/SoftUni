using TeamBuilder.Models;

namespace TeamBuilder.Services.Contracts
{
    public interface IInvitationService
    {
        void AddInvite(User invitedUser, Team teamToInvite);

        void AcceptInvite(User user, Team team);

        bool IsInviteExisting(string teamName, User user);

        void DeclineInvite(User user, Team team);

        void Remove(Team team);
    }
}