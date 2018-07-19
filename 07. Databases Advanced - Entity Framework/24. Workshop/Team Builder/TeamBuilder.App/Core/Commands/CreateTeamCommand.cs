using System;
using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.App.Core.Commands
{
    public class CreateTeamCommand : ICommand
    {
        private readonly ITeamService teamService;

        public CreateTeamCommand(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public string Execute(string[] commandArg)
        {
            string name = commandArg[0];
            ValidateName(name);

            string acronym = commandArg[1];
            ValidateAcronym(acronym);

            string description = commandArg.Length == 3 ? commandArg[2] : null;

            User creator = Session.Session.GetCurrentUser();

            Team team = new Team
            {
                Name = name,
                Description = description,
                Acronym = acronym,
                Creator = creator
            };

            this.teamService.AddTeam(team);

            return $"Team {name} successfully created!";
        }

        private void ValidateName(string name)
        {
            if (this.teamService.IsTeamExisting(name))
            {
                string errMsg = String.Format(Constants.ErrorMessages.TeamExists, name);
                throw new ArgumentException(errMsg);
            }
        }

        private void ValidateAcronym(string acronym)
        {
            if (acronym.Length != 3)
            {
                string errMsg = String.Format(Constants.ErrorMessages.InvalidAcronym, acronym);
                throw new ArgumentException(errMsg);
            }
        }
    }
}