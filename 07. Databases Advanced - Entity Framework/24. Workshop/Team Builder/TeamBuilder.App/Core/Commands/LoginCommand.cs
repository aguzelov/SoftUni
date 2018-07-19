using System;
using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.App.Core.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IUserService userService;

        public LoginCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] commandArg)
        {
            Check.CheckLength(2, commandArg);

            string username = commandArg[0];
            string password = commandArg[1];

            User user = this.userService.GetUser(username);

            if (user == null || user.Password != password || user.IsDeleted == true)
            {
                string errMsg = Constants.ErrorMessages.UserOrPasswordIsInvalid;
                throw new ArgumentException(errMsg);
            }

            Session.Session.LogIn(user);

            return $"User {username} successfully logged in!";
        }
    }
}