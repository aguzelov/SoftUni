using TeamBuilder.Models;

namespace TeamBuilder.Services.Contracts
{
    public interface ITeamEventService
    {
        void AddEventTeam(Event @event, Team team);

        bool IsEventTeamExist(Event @event, Team team);
    }
}