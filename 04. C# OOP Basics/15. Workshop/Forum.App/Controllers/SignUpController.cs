namespace Forum.App.Controllers
{
    using Forum.App;
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;

    public class SignUpController : IController, IReadUserInfoController
    {
        private const string DETAILS_ERROR = "Invalid Username or Password!";
        private const string USERNAME_TAKEN_ERROR = "Username already in use!";

        public string Username { get; private set; }

        private string Password { get; set; }

        private string ErroMessage { get; set; }

        private enum Command
        {
            ReadUsername,
            ReadPassword,
            SingUp,
            Back
        }

        public enum SingUpStatus
        {
            Success,
            DetailsError,
            UsernameTakenError
        }

        private void ResetSignUp()
        {
            this.ErroMessage = string.Empty;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    this.ReadUsername();
                    return MenuState.Signup;

                case Command.ReadPassword:
                    this.ReadPassword();
                    return MenuState.Signup;

                case Command.SingUp:
                    SingUpStatus singUp = UserService.TrySignUpUser(this.Username, this.Password);
                    switch (singUp)
                    {
                        case SingUpStatus.Success:
                            return MenuState.SuccessfulLogIn;

                        case SingUpStatus.DetailsError:
                            this.ErroMessage = DETAILS_ERROR;
                            return MenuState.SignUpError;

                        case SingUpStatus.UsernameTakenError:
                            this.ErroMessage = USERNAME_TAKEN_ERROR;
                            return MenuState.SignUpError;

                        default:
                            break;
                    }
                    return MenuState.SignUpError;

                case Command.Back:
                    this.ResetSignUp();
                    return MenuState.Back;
            }

            throw new System.InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            return new SignUpView(this.ErroMessage);
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }
    }
}