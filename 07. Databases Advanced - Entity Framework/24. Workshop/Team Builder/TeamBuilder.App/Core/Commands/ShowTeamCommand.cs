using System;
using System.Text;
using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Models;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.App.Core.Commands
{
    public class ShowTeamCommand : ICommand
    {
        private readonly ITeamService teamService;
        private readonly IUserService userService;

        public ShowTeamCommand(ITeamService teamService, IUserService userService)
        {
            this.teamService = teamService;
            this.userService = userService;
        }

        public string Execute(string[] commandArg)
        {
            Check.CheckLength(1, commandArg);

            string teamName = commandArg[0];
            ValidateTeam(teamName, out TeamMembersDto[] teams);

            StringBuilder sb = new StringBuilder();
            foreach (var team in teams)
            {
                sb.AppendLine($"{team.Name} {team.Acronym}");
                sb.AppendLine("Members:");
                foreach (var user in team.Users)
                {
                    int id = user.UserId;
                    User member = this.userService.GetUser(id);
                    sb.AppendLine($"-{member.Username}");
                }
            }

            return sb.ToString().Trim();
        }

        private void ValidateTeam<TModel>(string teamName, out TModel[] teams)
        {
            bool isExist = this.teamService.IsTeamExisting(teamName);
            if (!isExist)
            {
                string errMsg = String.Format(Constants.ErrorMessages.TeamNotFound, teamName);
                throw new ArgumentException(errMsg);
            }

            teams = this.teamService.GetAllEvents<TModel>(teamName);
        }
    }
}