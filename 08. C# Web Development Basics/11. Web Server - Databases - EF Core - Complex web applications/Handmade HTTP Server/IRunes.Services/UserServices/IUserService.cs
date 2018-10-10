using IRunes.Models;

namespace IRunes.Services.UserServices
{
    public interface IUserService
    {
        User Get(string username);

        void Add(string username, string password, string email);

        void Add(User user);

        bool Exsist(string username, string password);
    }
}