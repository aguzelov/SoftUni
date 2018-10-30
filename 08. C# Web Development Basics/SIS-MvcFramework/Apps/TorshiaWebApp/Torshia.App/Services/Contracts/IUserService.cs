using Torshia.App.ViewModels;
using Torshia.Models;

namespace Torshia.App.Services.Contracts
{
    public interface IUserService
    {
        bool Validate(UserLoginView view);

        bool Add(UserRegisterView view);

        User GetUser(string username);
    }
}