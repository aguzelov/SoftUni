namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Client.Validation;
    using PhotoShare.Services.Contracts;

    [CredentialAttribute(true)]
    public class DeleteUserCommand : ICommand
    {
        private readonly IUserService service;

        public DeleteUserCommand(IUserService service)
        {
            this.service = service;
        }

        // DeleteUser <username>
        public string Execute(string[] data)
        {
            string username = data[0];

            service.DeleteUser(username);

            return $"User {username} was deleted successfully!";
        }
    }
}