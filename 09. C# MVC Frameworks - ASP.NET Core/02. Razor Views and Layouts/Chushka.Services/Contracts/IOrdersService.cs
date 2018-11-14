using System.Collections.Generic;

namespace Chushka.Services.Contracts
{
    public interface IOrdersService
    {
        ICollection<T> All<T>();

        bool Order(string productId, string username);
    }
}