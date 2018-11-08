using System.Collections.Generic;

namespace FDMC.Service.Contracts
{
    public interface ICatService
    {
        bool Add(string name, int age, string breed, string imageUrl);

        T GetById<T>(int id);

        ICollection<T> All<T>();
    }
}