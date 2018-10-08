using SIS.Data;
using SIS.Models;
using System.Collections.Generic;
using System.Linq;

namespace SIS.Services.CakeServices
{
    public class CakeService : ICakeService
    {
        private readonly ByTheCakeContext _context;

        public CakeService(ByTheCakeContext context)
        {
            this._context = context;
        }

        public void Add(string name, decimal price, string url)
        {
            var cake = new Product()
            {
                Name = name,
                Price = price,
                ImageURL = url
            };

            this._context.Products.Add(cake);
            this._context.SaveChanges();
        }

        public ICollection<Product> GetAll()
        {
            var cakes = this._context.Products.ToArray();

            return cakes;
        }

        public ICollection<Product> GetAll(string searchedCakes)
        {
            var cakes = this._context.Products
                .Where(c => c.Name.Contains(searchedCakes))
                .ToArray();

            return cakes;
        }

        public Product Get(string name)
        {
            var cake = this._context.Products.FirstOrDefault(p => p.Name == name);

            return cake;
        }

        public Product Get(int id)
        {
            var cake = this._context.Products.Find(id);

            return cake;
        }
    }
}