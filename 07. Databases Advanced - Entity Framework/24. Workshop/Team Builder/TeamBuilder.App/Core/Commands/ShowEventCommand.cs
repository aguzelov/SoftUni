using System;
using System.Linq;
using System.Text;
using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Models;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.App.Core.Commands
{
    public class ShowEventCommand : ICommand
    {
        private readonly IEventService eventService;
        private readonly ITeamService teamService;

        public ShowEventCommand(IEventService eventService, ITeamService teamService)
        {
            this.eventService = eventService;
            this.teamService = teamService;
        }

        public string Execute(string[] commandArg)
        {
            Check.CheckLength(1, commandArg);

            string eventName = commandArg[0];
            ValidateEvents(eventName, out EventTeamsDto[] events);

            EventTeamsDto eventTeamsDto = events.OrderByDescending(e => e.StartDate).First();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{eventTeamsDto.Name} " +
                $"{eventTeamsDto.StartDate.ToString("dd/MM/yyyy HH:mm")} " +
                $"{eventTeamsDto.EndDate.ToString("dd/MM/yyyy HH:mm")}");
            sb.AppendLine($"{eventTeamsDto.Description}");
            sb.AppendLine("Teams:");
            foreach (var teamId in eventTeamsDto.Teams)
            {
                int id = teamId.TeamId;
                Team team = this.teamService.GetTeam(id);
                sb.AppendLine($"-{team.Name}");
            }

            return sb.ToString().Trim();
        }

        private void ValidateEvents<TModel>(string eventName, out TModel[] events)
        {
            bool isExist = this.eventService.IsEventExisting(eventName);
            if (!isExist)
            {
                string errMsg = String.Format(Constants.ErrorMessages.EventNotFound, eventName);
                throw new ArgumentException(errMsg);
            }

            events = this.eventService.GetAllEvents<TModel>(eventName);
        }
    }
}