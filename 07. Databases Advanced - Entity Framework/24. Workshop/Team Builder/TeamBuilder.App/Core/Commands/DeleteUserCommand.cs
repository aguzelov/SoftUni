using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.App.Core.Commands
{
    public class DeleteUserCommand : ICommand
    {
        private readonly IUserService userService;

        public DeleteUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] commandArg)
        {
            Check.CheckLength(0, commandArg);

            User user = Session.Session.LogOut();

            this.userService.DeleteUser(user);

            return $"User {user.Username} was deleted successfully!";
        }
    }
}