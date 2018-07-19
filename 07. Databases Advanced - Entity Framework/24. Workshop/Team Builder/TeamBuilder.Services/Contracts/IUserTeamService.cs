using TeamBuilder.Models;

namespace TeamBuilder.Services.Contracts
{
    public interface IUserTeamService
    {
        bool IsMemberOfTeam(string teamName, string username);

        void AddMember(User user, Team team);

        void RemoveTeam(Team team);

        void RemoveUserFromTeam(Team team, User user);
    }
}