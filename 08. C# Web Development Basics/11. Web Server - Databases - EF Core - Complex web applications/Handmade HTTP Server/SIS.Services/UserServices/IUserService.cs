using SIS.Models;

namespace SIS.Services.UserServices
{
    public interface IUserService
    {
        User Get(string username);

        void Add(string name, string username, string password);

        void Add(User user);

        bool Exsist(string username, string password);
    }
}