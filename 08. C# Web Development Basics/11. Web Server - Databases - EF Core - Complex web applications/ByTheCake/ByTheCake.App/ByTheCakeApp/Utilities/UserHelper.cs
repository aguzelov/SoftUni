using System.Security.Cryptography;
using System.Text;

namespace ByTheCake.App.ByTheCakeApp.Utilities
{
    public static class UserHelper
    {
        public static bool ValidateUserInput(string name, string username, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                !ValidatePassword(password, confirmPassword))
            {
                return false;
            }

            return true;
        }

        public static bool ValidateUserInput(string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            return true;
        }

        private static bool ValidatePassword(string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                return false;
            }

            return true;
        }

        public static string ComputePassword(string password)
        {
            string hashString;
            using (var sha256 = SHA256Managed.Create())
            {
                var hash = sha256.ComputeHash(Encoding.Default.GetBytes(password));
                hashString = ToHex(hash);
            }

            return hashString;
        }

        private static string ToHex(byte[] bytes, bool upperCase = false)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));
            return result.ToString();
        }
    }
}