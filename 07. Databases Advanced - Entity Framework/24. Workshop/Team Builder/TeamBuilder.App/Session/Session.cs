using System;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;

namespace TeamBuilder.App.Session
{
    public static class Session
    {
        private static User currentUser;

        public static User GetCurrentUser()
        {
            if (currentUser == null)
            {
                string errMsg = Constants.ErrorMessages.LoginFirst;
                throw new InvalidOperationException(errMsg);
            }

            return currentUser;
        }

        public static void LogIn(User user)
        {
            if (currentUser != null)
            {
                string errMsg = Constants.ErrorMessages.LogoutFirst;
                throw new InvalidOperationException(errMsg);
            }
            currentUser = user;
        }

        public static User LogOut()
        {
            if (currentUser == null)
            {
                string errMsg = Constants.ErrorMessages.LoginFirst;
                throw new InvalidOperationException(errMsg);
            }

            User user = currentUser;

            currentUser = null;

            return user;
        }
    }
}