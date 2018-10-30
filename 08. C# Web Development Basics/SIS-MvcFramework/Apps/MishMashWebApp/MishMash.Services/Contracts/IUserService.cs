using MishMash.Models;

namespace MishMash.Services
{
    public interface IUserService
    {
        bool Add(string username, string password, string confirmPassword, string email, string role);

        bool Contains(string username, string password);

        User GetUser(string username);
    }
}