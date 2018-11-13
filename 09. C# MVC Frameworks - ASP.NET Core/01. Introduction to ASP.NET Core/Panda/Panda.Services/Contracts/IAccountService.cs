using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Panda.Services.Contracts
{
    public interface IAccountService
    {
        Task<bool> Contains(string username);

        Task<T> GetUser<T>(string username);

        Task<bool> Add(string username, string password, string confirmPassword, string email);

        void SingIn(string username, string password);

        void SingOut();

        Task<bool> IsInRole(string username, string role);

        ICollection<string> GetAllUsersUsername();
    }
}