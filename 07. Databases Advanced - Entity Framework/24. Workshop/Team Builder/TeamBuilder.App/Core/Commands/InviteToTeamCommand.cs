using System;
using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.App.Core.Commands
{
    public class InviteToTeamCommand : ICommand
    {
        private readonly IInvitationService invitationService;
        private readonly ITeamService teamService;
        private readonly IUserService userService;
        private readonly IUserTeamService userTeamService;

        public InviteToTeamCommand(IInvitationService invitationService, ITeamService teamService, IUserService userService, IUserTeamService userTeamService)
        {
            this.invitationService = invitationService;
            this.teamService = teamService;
            this.userService = userService;
            this.userTeamService = userTeamService;
        }

        public string Execute(string[] commandArg)
        {
            Check.CheckLength(2, commandArg);

            string teamName = commandArg[0];
            ValidateTeam(teamName, out Team team);

            string username = commandArg[1];
            ValidateUser(username, out User userToIvite);

            if (userToIvite.Id == team.CreatorId)
            {
                this.invitationService.AddInvite(userToIvite, team);
                return $"Team {team.Name} invited {userToIvite.Username}!";
            }

            User currentUser = Session.Session.GetCurrentUser();

            ValidateIfIsAllowed(currentUser, team, userToIvite);

            ValidateInvite(userToIvite, teamName);

            this.invitationService.AddInvite(userToIvite, team);

            return $"Team {teamName} invited {username}!";
        }

        private void ValidateInvite(User user, string teamName)
        {
            bool isInviteExisting = this.invitationService.IsInviteExisting(teamName, user);
            if (isInviteExisting)
            {
                string errMsg = Constants.ErrorMessages.InviteIsAlreadySent;
                throw new InvalidOperationException(errMsg);
            }
        }

        private void ValidateIfIsAllowed(User currentUser, Team team, User userToInvite)
        {
            bool isCurrentUserCraetorOfTeam = this.teamService.IsUserCreatorOfTeam(team.Name, currentUser);

            //bool isCurrentUserMemberOfTeam = this.userTeamService.IsMemberOfTeam(team.Name, currentUser.Username);

            bool isUserToIviteMemberOfTeam = this.userTeamService.IsMemberOfTeam(team.Name, userToInvite.Username);

            if (!isCurrentUserCraetorOfTeam || isUserToIviteMemberOfTeam)
            {
                string errMsg = Constants.ErrorMessages.NotAllowed;
                throw new ArgumentException(errMsg);
            }
        }

        private void ValidateUser(string username, out User user)
        {
            if (!this.userService.IsUserExisting(username))
            {
                string errMsg = Constants.ErrorMessages.TeamOrUserNotExist;
                throw new ArgumentException(errMsg);
            }

            user = this.userService.GetUser(username);
        }

        private void ValidateTeam(string teamName, out Team team)
        {
            if (!this.teamService.IsTeamExisting(teamName))
            {
                string errMsg = Constants.ErrorMessages.TeamOrUserNotExist;
                throw new ArgumentException(errMsg);
            }

            team = this.teamService.GetTeam(teamName);
        }
    }
}