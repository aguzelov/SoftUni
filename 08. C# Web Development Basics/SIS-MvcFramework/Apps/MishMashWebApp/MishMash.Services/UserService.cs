using MishMash.Data;
using MishMash.Models;
using MishMash.Models.Enums;
using SIS.MvcFramework.Services;
using System;
using System.Linq;

namespace MishMash.Services
{
    public class UserService : IUserService
    {
        private readonly MishMashContext context;
        private readonly IHashService hashService;

        public UserService(MishMashContext context, IHashService hashService)
        {
            this.context = context;
            this.hashService = hashService;
        }

        public bool Add(string username, string password, string confirmPassword, string email, string roleStr)
        {
            if (!IsValid(username, password, confirmPassword, email, roleStr))
            {
                return false;
            }

            var isParsed = Enum.TryParse<UserRole>(roleStr, true, out UserRole role);
            if (isParsed == false)
            {
                return false;
            }

            if (!this.context.Users.Any())
            {
                role = UserRole.Admin;
            }

            var hashedPassword = this.hashService.Hash(password);

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

        private bool IsValid(string username, string password, string confirmPassword, string email, string roleStr)
        {
            if (username == null ||
                password == null ||
                confirmPassword == null ||
                email == null ||
                roleStr == null ||
                password != confirmPassword)
            {
                return false;
            }

            return true;
        }
    }
}