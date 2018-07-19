using System;
using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.App.Core.Commands
{
    public class DeclineInviteCommand : ICommand
    {
        private readonly IInvitationService invitationService;
        private readonly ITeamService teamService;

        public DeclineInviteCommand(IInvitationService invitationService, ITeamService teamService)
        {
            this.invitationService = invitationService;
            this.teamService = teamService;
        }

        public string Execute(string[] commandArg)
        {
            Check.CheckLength(1, commandArg);

            string teamName = commandArg[0];

            User user = Session.Session.GetCurrentUser();

            Validate(teamName, user, out Team team);

            this.invitationService.DeclineInvite(user, team);

            return $"Invite from {teamName} declined.";
        }

        private void Validate(string teamName, User user, out Team team)
        {
            bool isExist = this.teamService.IsTeamExisting(teamName);
            if (!isExist)
            {
                string errMsg = String.Format(Constants.ErrorMessages.TeamNotFound, teamName);
                throw new ArgumentException(errMsg);
            }

            bool hasInvite = this.invitationService.IsInviteExisting(teamName, user);
            if (!hasInvite)
            {
                string errMsg = String.Format(Constants.ErrorMessages.InviteNotFound, teamName);
                throw new ArgumentException(errMsg);
            }

            team = this.teamService.GetTeam(teamName);
        }
    }
}