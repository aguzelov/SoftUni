using ProductShop.Models;
using System.Linq;

namespace ProductShop.Services.Contracts
{
    public interface IProductService
    {
        void AddProduct(Product product);

        void AddRange(Product[] products);

        IQueryable<TModel> GetInPriceRange<TModel>(decimal min, decimal max);
    }
}