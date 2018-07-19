using TeamBuilder.Models;

namespace TeamBuilder.Services.Contracts
{
    public interface IUserService
    {
        void AddUser(User user);

        User GetUser(string username);

        User GetUser(int id);

        bool IsUserExisting(string username);

        void DeleteUser(User user);
    }
}