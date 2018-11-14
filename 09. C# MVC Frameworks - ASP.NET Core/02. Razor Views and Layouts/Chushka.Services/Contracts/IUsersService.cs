using System.Threading.Tasks;

namespace Chushka.Services.Contracts
{
    public interface IUsersService
    {
        Task<bool> Register(string username,
            string password,
            string confirmPassword,
            string email,
            string fullName);

        Task<bool> Login(string username,
            string password);

        void Logout();
    }
}