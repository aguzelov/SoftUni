using Chushka.Models;
using Chushka.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Chushka.Services
{
    public class UsersService : IUsersService
    {
        private readonly SignInManager<User> singInManager;
        private readonly UserManager<User> userManager;

        public UsersService(SignInManager<User> singInManager, UserManager<User> userManager)
        {
            this.singInManager = singInManager;
            this.userManager = userManager;
        }

        public async Task<bool> Login(string username, string password)
        {
            var user = this.GetUser(username).Result;

            if (user == null)
            {
                return false;
            }

            var result = await this.singInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task<bool> Register(string username, string password, string confirmPassword, string email, string fullName)
        {
            if (username == null ||
                password == null ||
                confirmPassword == null ||
                email == null ||
                fullName == null)
                return false;

            if (password != confirmPassword)
                return false;

            var user = new User
            {
                UserName = username,
                Email = email,
                FullName = fullName
            };

            var userCreateResult = await this.userManager.CreateAsync(user, password);

            if (!userCreateResult.Succeeded)
                return false;

            IdentityResult addRoleResult = null;

            if (this.userManager.Users.Count() == 1)
            {
                addRoleResult = await this.userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                addRoleResult = await this.userManager.AddToRoleAsync(user, "User");
            }

            if (!addRoleResult.Succeeded)
                return false;

            return true;
        }

        public async Task<User> GetUser(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);

            return user;
        }

        public async void Logout()
        {
            await this.singInManager.SignOutAsync();
        }
    }
}