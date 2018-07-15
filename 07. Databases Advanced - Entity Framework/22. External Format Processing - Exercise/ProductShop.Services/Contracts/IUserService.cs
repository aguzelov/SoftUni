using ProductShop.Models;
using System.Linq;

namespace ProductShop.Services.Contracts
{
    public interface IUserService
    {
        void AddUser(User user);

        void AddRange(User[] users);

        IQueryable<TModel> GetAllWith<TModel>();

        User[] GetAll();
    }
}