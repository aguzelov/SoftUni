using AutoMapper.QueryableExtensions;
using System.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamBuilderContext context;

        public TeamService(TeamBuilderContext context)
        {
            this.context = context;
        }

        public void AddTeam(Team team)
        {
            this.context.Add(team);

            this.context.SaveChanges();
        }

        public Team GetTeam(string teamName)
        {
            Team team = this.context.Teams.FirstOrDefault(t => t.Name == teamName);

            return team;
        }

        public Team GetTeam(int id)
        {
            Team team = this.context.Teams.Find(id);

            return team;
        }

        public TModel[] GetAllEvents<TModel>(string teamName)
        {
            TModel[] teams = this.context.Teams
                .Where(e => e.Name == teamName)
                .ProjectTo<TModel>()
                .ToArray();

            return teams;
        }

        public void Dispand(Team team)
        {
            this.context.Teams.Remove(team);
            this.context.SaveChanges();
        }

        public bool IsTeamExisting(string teamName)
        {
            return this.context.Teams.Any(t => t.Name == teamName);
        }

        public bool IsUserCreatorOfTeam(string teamName, User user)
        {
            Team team = this.context.Teams.FirstOrDefault(t => t.Name == teamName);

            return team.Creator == user;
        }
    }
}