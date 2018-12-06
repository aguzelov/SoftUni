using AutoMapper;
using Eventures.Models;
using Eventures.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Services
{
    public class UsersService : IUsersService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersService(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._mapper = mapper;
            this._roleManager = roleManager;
        }

        public bool Login(string username, string password, bool rememberMe)
        {
            var result = this._signInManager.PasswordSignInAsync(username, password, rememberMe, false).GetAwaiter().GetResult();

            return result.Succeeded;
        }

        public void Logout()
        {
            this._signInManager.SignOutAsync().Wait();
        }

        public async Task<bool> Register(string username, string email, string password, string confirmPassword, string firstName, string lastName, string uniqueCitizenNumber)
        {
            if (username == null ||
                email == null ||
                password == null ||
                confirmPassword == null ||
                firstName == null ||
                lastName == null ||
                uniqueCitizenNumber == null ||
                password != confirmPassword)
            {
                return false;
            }

            var user = new User
            {
                UserName = username,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                UniqueCitizenNumber = uniqueCitizenNumber
            };

            var result = await this._userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                if (this._userManager.Users.Count() == 1)
                {
                    await this._userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    await this._userManager.AddToRoleAsync(user, "User");
                }
            }

            return result.Succeeded;
        }

        public ICollection<T> All<T>(string roleName)
        {
            var users = this._userManager.GetUsersInRoleAsync(roleName).GetAwaiter().GetResult();

            var model = users.Select(u => this._mapper.Map<T>(u)).ToList();

            return model;
        }

        public async Task<bool> Promote(string id)
        {
            var user = this._userManager.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return false;
            }

            var isAdmin = await this._userManager.IsInRoleAsync(user, "Admin");
            if (!isAdmin)
            {
                var result = await this._userManager.AddToRoleAsync(user, "Admin");
                await this._userManager.RemoveFromRoleAsync(user, "User");

                return result.Succeeded;
            }

            return true;
        }

        public async Task<bool> Demote(string id)
        {
            var user = this._userManager.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return false;
            }

            var isUser = await this._userManager.IsInRoleAsync(user, "User");
            if (!isUser)
            {
                var result = await this._userManager.AddToRoleAsync(user, "User");
                await this._userManager.RemoveFromRoleAsync(user, "Admin");

                return result.Succeeded;
            }

            return true;
        }
    }
}