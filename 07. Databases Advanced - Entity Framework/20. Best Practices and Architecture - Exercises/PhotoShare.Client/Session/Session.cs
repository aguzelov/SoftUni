using PhotoShare.Models;

namespace PhotoShare.Client
{
    public static class Session
    {
        private static User user;

        public static User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
    }
}