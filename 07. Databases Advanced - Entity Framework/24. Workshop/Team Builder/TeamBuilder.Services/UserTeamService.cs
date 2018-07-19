using System.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.Services
{
    public class UserTeamService : IUserTeamService
    {
        private readonly TeamBuilderContext context;

        public UserTeamService(TeamBuilderContext context)
        {
            this.context = context;
        }

        public void AddMember(User user, Team team)
        {
            UserTeam userTeam = new UserTeam
            {
                User = user,
                Team = team
            };

            this.context.UserTeams.Add(userTeam);

            this.context.SaveChanges();
        }

        public void RemoveTeam(Team team)
        {
            UserTeam[] userTeams = this.context.UserTeams
                .Where(ut => ut.Team == team)
                .ToArray();

            this.context.UserTeams.RemoveRange(userTeams);

            this.context.SaveChanges();
        }

        public void RemoveUserFromTeam(Team team, User user)
        {
            UserTeam userTeam = this.context.UserTeams.First(ut => ut.TeamId == team.Id && ut.UserId == user.Id);

            this.context.UserTeams.Remove(userTeam);

            this.context.SaveChanges();
        }

        public bool IsMemberOfTeam(string teamName, string username)
        {
            return this.context.UserTeams.Any(ut => ut.Team.Name == teamName && ut.User.Username == username);
        }
    }
}