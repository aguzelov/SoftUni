namespace Forum.App.Services
{
    using Forum.Data;
    using Forum.Models;
    using System.Linq;
    using static Forum.App.Controllers.SignUpController;

    public static class UserService
    {
        public static bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            ForumData forumData = new ForumData();

            bool userExists = forumData.Users.Any(u => u.Username == username && u.Password == password);

            return userExists;
        }

        public static SingUpStatus TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validUsername || !validPassword)
            {
                return SingUpStatus.DetailsError;
            }

            ForumData forumData = new ForumData();

            bool userAlreadyExists = forumData.Users.Any(u => u.Username == username);

            if (!userAlreadyExists)
            {
                int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
                User user = new User(userId, username, password);
                forumData.Users.Add(user);
                forumData.SaveChanges();

                return SingUpStatus.Success;
            }

            return SingUpStatus.UsernameTakenError;
        }

        public static User GetUser(int userId)
        {
            ForumData forumData = new ForumData();

            User user = forumData.Users.Find(u => u.Id == userId);

            return user;
        }

        public static User GetUser(string username, ForumData forumData)
        {
            User user = forumData.Users.Find(u => u.Username == username);

            return user;
        }
    }
}