using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.Models;
using ProductShop.Services.Contracts;
using System.Linq;

namespace ProductShop.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductShopContext context;

        public ProductService(ProductShopContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);

            context.SaveChanges();
        }

        public void AddRange(Product[] products)
        {
            context.Products.AddRange(products);

            context.SaveChanges();
        }

        public IQueryable<TModel> GetInPriceRange<TModel>(decimal min, decimal max)
        {
            var products = context.Products
                .Where(p => p.Price >= min && p.Price <= max)
                .ProjectTo<TModel>();

            return products;
        }
    }
}