using TeamBuilder.Models;

namespace TeamBuilder.Services.Contracts
{
    public interface ITeamService
    {
        void AddTeam(Team team);

        Team GetTeam(string teamName);

        Team GetTeam(int id);

        TModel[] GetAllEvents<TModel>(string teamName);

        void Dispand(Team team);

        bool IsTeamExisting(string teamName);

        bool IsUserCreatorOfTeam(string teamName, User user);
    }
}