using SIS.MvcFramework.Services;
using System.Linq;
using Torshia.App.Services.Contracts;
using Torshia.App.ViewModels;
using Torshia.Data;
using Torshia.Models;

namespace Torshia.App.Services
{
    public class UserService : IUserService
    {
        private readonly TorshiaCotnext cotnext;
        private readonly IHashService hashService;

        public UserService(TorshiaCotnext cotnext, IHashService hashService)
        {
            this.cotnext = cotnext;
            this.hashService = hashService;
        }

        public User GetUser(string username)
        {
            return this.cotnext.Users.FirstOrDefault(u => u.Username == username);
        }

        public bool Validate(UserLoginView view)
        {
            if (!Validate(view.Username, view.Password))
            {
                return false;
            }

            var hashPassword = this.hashService.Hash(view.Password);

            return this.cotnext.Users
                  .Any(u => u.Username == view.Username &&
                           u.Password == hashPassword);
        }

        public bool Add(UserRegisterView view)
        {
            if (!Validate(view.Username, view.Password, view.ConfirmPassword, view.Email))
            {
                return false;
            }

            var hashPassword = this.hashService.Hash(view.Password);

            var exist = this.cotnext.Users
                  .Any(u => u.Username == view.Username &&
                           u.Password == hashPassword &&
                           u.Email == view.Email);

            if (exist)
            {
                return false;
            }

            var role = Role.User;
            if (!this.cotnext.Users.Any())
            {
                role = Role.Admin;
            }

            this.cotnext.Users.Add(new User
            {
                Username = view.Username,
                Password = hashPassword,
                Email = view.Email,
                Role = role
            });

            this.cotnext.SaveChanges();

            return true;
        }

        private bool Validate(string username, string password, string confirmPassword, string email)
        {
            return username != null &&
                    password != null &&
                    confirmPassword != null &&
                    email != null &&
                    password == confirmPassword;
        }

        private bool Validate(string username, string password)
        {
            return username != null && password != null;
        }
    }
}