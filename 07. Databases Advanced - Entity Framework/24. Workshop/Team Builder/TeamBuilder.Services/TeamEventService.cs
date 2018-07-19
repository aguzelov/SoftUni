using System.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.Services
{
    public class TeamEventService : ITeamEventService
    {
        private readonly TeamBuilderContext context;

        public TeamEventService(TeamBuilderContext context)
        {
            this.context = context;
        }

        public void AddEventTeam(Event @event, Team team)
        {
            TeamEvent teamEvent = new TeamEvent
            {
                Event = @event,
                Team = team
            };

            this.context.TeamEvents.Add(teamEvent);

            this.context.SaveChanges();
        }

        public bool IsEventTeamExist(Event @event, Team team)
        {
            return this.context.TeamEvents.Any(et => et.Event == @event && et.Team == team);
        }
    }
}