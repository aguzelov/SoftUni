using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface IUserService
    {
        User GetUserByUsername(string username);

        User GetsUserByUsernameAndPassword(string username, string password);

        User CreateUser(string username, string password, string repPassword, string email);

        User ModifyUser(string username, string property, string newValue);

        void DeleteUser(string username);

        bool Exist(string username);
    }
}