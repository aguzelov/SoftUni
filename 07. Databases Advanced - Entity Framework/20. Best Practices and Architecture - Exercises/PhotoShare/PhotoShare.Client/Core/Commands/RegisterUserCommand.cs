namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Client.Validation;
    using PhotoShare.Services.Contracts;

    [CredentialAttribute(false)]
    public class RegisterUserCommand : ICommand
    {
        private readonly IUserService service;

        public RegisterUserCommand(IUserService service)
        {
            this.service = service;
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];
            string repeatPassword = data[2];
            string email = data[3];

            User user = service.CreateUser(username, password, repeatPassword, email);

            return "User " + user.Username + " was registered successfully!";
        }
    }
}