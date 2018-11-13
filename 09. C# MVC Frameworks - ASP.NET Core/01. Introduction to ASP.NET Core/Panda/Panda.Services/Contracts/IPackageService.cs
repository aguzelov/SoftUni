using System.Collections.Generic;

namespace Panda.Services.Contracts
{
    public interface IPackageService
    {
        IDictionary<string, ICollection<T>> GetUserPackagesByStatus<T>(string username);

        T GetById<T>(string id);

        string Add(string description, string shippingAddress, float weight, string recipient);

        ICollection<T> GetPackagesByStatus<T>(string status);

        bool Ship(string id);

        bool Deliver(string id);

        bool Acquire(string id);
    }
}