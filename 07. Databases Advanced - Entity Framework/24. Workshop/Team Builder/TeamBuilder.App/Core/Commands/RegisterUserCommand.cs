using System;
using System.Linq;
using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.App.Core.Commands
{
    public class RegisterUserCommand : ICommand
    {
        private readonly IUserService userService;

        public RegisterUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] commandArg)
        {
            Check.CheckLength(7, commandArg);

            string username = commandArg[0];
            ValidateUsername(username);

            string password = commandArg[1];
            ValidatePassword(password);

            string repeatedPassword = commandArg[2];
            ValidatePasswordIsMatch(password, repeatedPassword);

            string firstName = commandArg[3];
            string lastName = commandArg[4];

            string ageStr = commandArg[5];
            TryParseAge(ageStr, out int age);

            string genderStr = commandArg[6];
            TryParseGender(genderStr, out Gender gender);

            User user = new User
            {
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                Password = password,
                Age = age,
                Gender = gender,
            };

            this.userService.AddUser(user);

            return $"User {user.Username} was registered successfully!";
        }

        private void ValidateUsername(string username)
        {
            if (username.Length < Constants.MinUsernameLength
                    || username.Length > Constants.MaxUsernameLength)
            {
                string errMsg = String.Format(Constants.ErrorMessages.UsernameNotValid, username);
                throw new ArgumentException(errMsg);
            }

            if (this.userService.IsUserExisting(username))
            {
                string errMsg = String.Format(Constants.ErrorMessages.UsernameIsTaken, username);
                throw new InvalidOperationException(errMsg);
            }
        }

        private void ValidatePassword(string password)
        {
            bool isCorrectLength = password.Length >= Constants.MinPasswordLength
                    && password.Length <= Constants.MaxPasswordLength;

            bool hasDigit = password.ToCharArray().Any(p => char.IsDigit(p));
            bool hasUpperCaseLetter = password.ToCharArray().Any(p => char.IsDigit(p));

            if (!isCorrectLength || !hasDigit || !hasUpperCaseLetter)
            {
                string errMsg = String.Format(Constants.ErrorMessages.PasswordNotValid, password);
                throw new ArgumentException(errMsg);
            }
        }

        private void TryParseAge(string ageStr, out int age)
        {
            bool isParsed = int.TryParse(ageStr, out age);
            if (!isParsed || age < 0)
            {
                string errMsg = String.Format(Constants.ErrorMessages.AgeNotValid, ageStr);
                throw new ArgumentException(errMsg);
            }
        }

        private void TryParseGender(string genderStr, out Gender gender)
        {
            try
            {
                gender = Enum.Parse<Gender>(genderStr, true);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException || ex is ArgumentException)
                {
                    string errMsg = String.Format(Constants.ErrorMessages.GenderNotValid, genderStr);
                    throw new ArgumentException(errMsg);
                }
                throw;
            }
        }

        private void ValidatePasswordIsMatch(string password, string repeatedPassword)
        {
            if (password != repeatedPassword)
            {
                string errMsg = Constants.ErrorMessages.PasswordDoesNotMatch;
                throw new InvalidOperationException(errMsg);
            }
        }
    }
}