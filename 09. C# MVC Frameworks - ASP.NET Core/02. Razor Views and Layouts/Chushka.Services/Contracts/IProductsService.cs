using System.Collections.Generic;

namespace Chushka.Services.Contracts
{
    public interface IProductsService
    {
        string Create(string name, decimal price, string description, string type);

        T Details<T>(string id);

        ICollection<T> GetAll<T>();

        bool Edit(string id, string name, decimal price, string description, string type);

        void Delete(string id);
    }
}