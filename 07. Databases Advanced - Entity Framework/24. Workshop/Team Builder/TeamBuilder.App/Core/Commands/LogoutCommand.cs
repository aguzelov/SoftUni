using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class LogoutCommand : ICommand
    {
        public string Execute(string[] commandArg)
        {
            Check.CheckLength(0, commandArg);

            User user = Session.Session.LogOut();

            return $"User {user.Username} successfully logged out!";
        }
    }
}