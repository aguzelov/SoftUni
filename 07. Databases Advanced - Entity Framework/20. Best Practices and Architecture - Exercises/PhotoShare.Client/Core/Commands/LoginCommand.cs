using PhotoShare.Client.Core.Commands.Contracts;
using PhotoShare.Client.Validation;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using System;

namespace PhotoShare.Client.Core.Commands
{
    [CredentialAttribute(false)]
    public class LoginCommand : ICommand
    {
        private readonly IUserService userService;

        public LoginCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(params string[] data)
        {
            string username = data[0];
            string password = data[1];

            User user = userService.GetsUserByUsernameAndPassword(username, password);

            if (Session.User == user)
            {
                throw new ArgumentException("You should logout first!");
            }

            Session.User = user;

            return $"User {user.Username} successfully logged in!";
        }
    }
}