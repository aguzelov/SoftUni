namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Client.Validation;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;
    using System.Linq;

    [CredentialAttribute(true)]
    public class ModifyUserCommand : ICommand
    {
        private readonly IUserService service;

        public ModifyUserCommand(IUserService service)
        {
            this.service = service;
        }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            string username = data[0];
            string property = data[1];
            string newValue = data[2];

            if (!new[] { "Password", "BornTown", "CurrentTown" }.Contains(property))
            {
                throw new ArgumentException($"Property {property} not supported!");
            }

            User user = service.ModifyUser(username, property, newValue);

            return $"User {user.Username} {property} is {newValue}";
        }
    }
}