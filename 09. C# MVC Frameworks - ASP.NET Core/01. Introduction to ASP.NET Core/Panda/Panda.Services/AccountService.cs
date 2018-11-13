using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Panda.Models;
using Panda.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> singInManager;
        private readonly IMapper mapper;

        public AccountService(UserManager<User> userManager, SignInManager<User> singInManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.singInManager = singInManager;
            this.mapper = mapper;
        }

        public async Task<bool> Add(string username, string password, string confirmPassword, string email)
        {
            if (password != confirmPassword) return false;

            var user = new User
            {
                UserName = username,
                Email = email
            };

            var result = await this.userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return false;
            }

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
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Contains(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);

            return user != null;
        }

        public async Task<T> GetUser<T>(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return default(T);
            }

            var model = this.mapper.Map<T>(user);

            return model;
        }

        public void SingIn(string username, string password)
        {
            var user = this.GetUser(username).GetAwaiter().GetResult();

           this.singInManager.SignInAsync(user, isPersistent: false).Wait();
        }

        public async void SingOut()
        {
            await this.singInManager.SignOutAsync();
        }

        public async Task<User> GetUser(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);

            return user;
        }

        public async Task<bool> IsInRole(string username, string role)
        {
            var user = await this.GetUser(username);

            var isInRole = await this.userManager.IsInRoleAsync(user, role);

            return isInRole;
        }

        public ICollection<string> GetAllUsersUsername()
        {
            var usernames = this.userManager.Users.Select(u => u.UserName).ToList();

            return usernames;
        }
    }
}