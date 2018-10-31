using Chushka.App.Data;
using Chushka.App.Models;
using SIS.MvcFramework.Services;
using System.Linq;

namespace Chushka.Services
{
    public class UserService : IUserService
    {
        private readonly ChushkaContext context;
        private readonly IHashService hashService;

        public UserService(ChushkaContext context, IHashService hashService)
        {
            this.context = context;
            this.hashService = hashService;
        }

        public bool Add(string username, string password, string confirmPassword, string email)
        {
            if (!IsValid(username, password, confirmPassword, email))
            {
                return false;
            }

            var role = Role.User;
            if (!this.context.Users.Any())
            {
                role = Role.Admin;
            }
            var hashedPassword = this.hashService.Hash(password);

            if (this.context.Users.Any(u => u.Username == username && u.Password == hashedPassword))
            {
                return false;
            }

            var user = new User
            {
                Username = username,
                Password = hashedPassword,
                Email = email,
                Role = role
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();

            return true;
        }

        public bool Contains(string username, string password)
        {
            if (!IsValid(username, password))
            {
                return false;
            }

            var hashedPassword = this.hashService.Hash(password);

            var user = this.context.Users.FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);

            return user != null;
        }

        public User GetUser(string username)
        {
            if (username == null)
            {
                return null;
            }

            return this.context.Users.FirstOrDefault(u => u.Username == username);
        }

        private bool IsValid(string username, string password)
        {
            if (username == null || password == null)
            {
                return false;
            }

            return true;
        }

        private bool IsValid(string username, string password, string confirmPassword, string email)
        {
            if (username == null ||
                password == null ||
                confirmPassword == null ||
                email == null ||
                password != confirmPassword)
            {
                return false;
            }

            return true;
        }
    }
}