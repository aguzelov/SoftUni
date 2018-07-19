using System;
using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.App.Core.Commands
{
    public class KickMemberCommand : ICommand
    {
        private readonly ITeamService teamService;
        private readonly IUserService userService;
        private readonly IUserTeamService userTeamService;

        public KickMemberCommand(ITeamService teamService, IUserService userService, IUserTeamService userTeamService)
        {
            this.teamService = teamService;
            this.userService = userService;
            this.userTeamService = userTeamService;
        }

        public string Execute(string[] commandArg)
        {
            string teamName = commandArg[0];
            ValidateTeam(teamName, out Team team);

            string username = commandArg[1];
            ValidateUser(username, out User user);

            ValidateUserIsMamberOfTeam(user, team);

            User currentUser = Session.Session.GetCurrentUser();
            ValidateIsAllowed(currentUser, team);

            ValidateCommand(user, currentUser);

            this.userTeamService.RemoveUserFromTeam(team, user);

            return $"User {username} was kicked from {teamName}!";
        }

        private void ValidateCommand(User user, User currentUser)
        {
            if (user == currentUser)
            {
                string errMsg = String.Format(Constants.ErrorMessages.CommandNotAllowed, nameof(DisbandCommand));
                throw new InvalidOperationException(errMsg);
            }
        }

        private void ValidateUserIsMamberOfTeam(User user, Team team)
        {
            bool isMember = this.userTeamService.IsMemberOfTeam(team.Name, user.Username);
            if (!isMember)
            {
                string errMsg = String.Format(Constants.ErrorMessages.NotPartOfTeam, user.Username, team.Name);
            }
        }

        private void ValidateIsAllowed(User currentUser, Team team)
        {
            if (currentUser.Id != team.CreatorId)
            {
                string errMsg = Constants.ErrorMessages.NotAllowed;
                throw new InvalidOperationException(errMsg);
            }
        }

        private void ValidateUser(string username, out User user)
        {
            if (!this.userService.IsUserExisting(username))
            {
                string errMsg = String.Format(Constants.ErrorMessages.UserNotFound, username);
                throw new ArgumentException(errMsg);
            }

            user = this.userService.GetUser(username);
        }

        private void ValidateTeam(string teamName, out Team team)
        {
            if (!this.teamService.IsTeamExisting(teamName))
            {
                string errMsg = String.Format(Constants.ErrorMessages.TeamNotFound, teamName);
                throw new ArgumentException(errMsg);
            }

            team = this.teamService.GetTeam(teamName);
        }
    }
}