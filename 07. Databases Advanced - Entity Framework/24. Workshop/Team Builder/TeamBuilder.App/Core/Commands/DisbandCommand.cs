using System;
using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.App.Core.Commands
{
    public class DisbandCommand : ICommand
    {
        private readonly ITeamService teamService;
        private readonly IUserTeamService userTeamService;
        private readonly IInvitationService invitationService;

        public DisbandCommand(ITeamService teamService, IUserTeamService userTeamService, IInvitationService invitationService)
        {
            this.teamService = teamService;
            this.userTeamService = userTeamService;
            this.invitationService = invitationService;
        }

        public string Execute(string[] commandArg)
        {
            Check.CheckLength(1, commandArg);

            string teamName = commandArg[0];

            ValidateTeam(teamName, out Team team);

            User user = Session.Session.GetCurrentUser();
            ValidateCreator(teamName, user);

            this.userTeamService.RemoveTeam(team);
            this.invitationService.Remove(team);
            this.teamService.Dispand(team);

            return $"{teamName} has disbanded!";
        }

        private void ValidateCreator(string teamName, User user)
        {
            bool isCreator = this.teamService.IsUserCreatorOfTeam(teamName, user);
            if (!isCreator)
            {
                string errMsg = Constants.ErrorMessages.NotAllowed;
                throw new InvalidOperationException(errMsg);
            }
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