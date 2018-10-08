using SIS.Models;
using System.Collections.Generic;

namespace SIS.Services.CakeServices
{
    public interface ICakeService
    {
        void Add(string name, decimal price, string url);

        ICollection<Product> GetAll();

        ICollection<Product> GetAll(string searchedCakes);

        Product Get(string name);

        Product Get(int id);
    }
}