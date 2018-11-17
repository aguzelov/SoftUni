using System.Threading.Tasks;

namespace Eventures.Services.Contracts
{
    public interface IUsersService
    {
        bool Login(string username, string password, bool rememberMe);

        Task<bool> Register(string username, string email, string password, string confirmPassword, string firstName, string lastName, string uniqueCitizenNumber);

        void Logout();
    }
}