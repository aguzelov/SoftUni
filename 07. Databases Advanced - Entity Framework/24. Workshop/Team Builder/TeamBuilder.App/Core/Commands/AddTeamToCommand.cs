using System;
using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.App.Core.Commands
{
    public class AddTeamToCommand : ICommand
    {
        private readonly IEventService eventService;
        private readonly ITeamService teamService;
        private readonly ITeamEventService teamEventService;

        public AddTeamToCommand(IEventService eventService, ITeamService teamService, ITeamEventService teamEventService)
        {
            this.eventService = eventService;
            this.teamService = teamService;
            this.teamEventService = teamEventService;
        }

        public string Execute(string[] commandArg)
        {
            Check.CheckLength(2, commandArg);

            string eventName = commandArg[0];
            ValidateEvent(eventName, out Event @event);

            string teamName = commandArg[1];
            ValidateTeam(teamName, out Team team);

            User user = Session.Session.GetCurrentUser();
            ValidateCreator(teamName, user);

            ValidateEventTeam(@event, team);

            this.teamEventService.AddEventTeam(@event, team);

            return $"Team {teamName} added for {eventName}!";
        }

        private void ValidateEventTeam(Event @event, Team team)
        {
            bool IsExist = this.teamEventService.IsEventTeamExist(@event, team);
            if (IsExist)
            {
                string errMsg = Constants.ErrorMessages.CannotAddSameTeamTwice;
                throw new InvalidOperationException(errMsg);
            }
        }

        private void ValidateCreator(string teamName, User user)
        {
            bool isCreator = this.teamService.IsUserCreatorOfTeam(teamName, user);
            if (!isCreator)
            {
                string errMsg = Constants.ErrorMessages.NotAllowed;
                throw new ArgumentException(errMsg);
            }
        }

        private void ValidateEvent(string eventName, out Event @event)
        {
            bool isExist = this.eventService.IsEventExisting(eventName);
            if (!isExist)
            {
                string errMsg = String.Format(Constants.ErrorMessages.EventNotFound, eventName);
                throw new ArgumentException(errMsg);
            }

            @event = this.eventService.GetEvent(eventName);
        }

        private void ValidateTeam(string teamName, out Team team)
        {
            bool isExist = this.teamService.IsTeamExisting(teamName);
            if (!isExist)
            {
                string errMsg = String.Format(Constants.ErrorMessages.TeamNotFound, teamName);
                throw new ArgumentException(errMsg);
            }

            team = this.teamService.GetTeam(teamName);
        }
    }
}