using PhotoShare.Client.Core.Commands.Contracts;
using PhotoShare.Client.Validation;
using System;

namespace PhotoShare.Client.Core.Commands
{
    [CredentialAttribute(true)]
    public class LogoutCommand : ICommand
    {
        public string Execute(params string[] data)
        {
            if (Session.User == null)
            {
                throw new InvalidOperationException("You should log in first in order to logout.");
            }

            string username = Session.User.Username;
            Session.User = null;

            return $"User {username} successfully logged out!";
        }
    }
}