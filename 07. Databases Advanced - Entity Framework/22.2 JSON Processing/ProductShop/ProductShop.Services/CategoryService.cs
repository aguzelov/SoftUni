using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Models;
using ProductShop.Services.Contracts;
using System.Linq;

namespace ProductShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductShopContext context;

        public CategoryService(ProductShopContext context)
        {
            this.context = context;
        }

        public void AddCategory(Category category)
        {
            context.Categories.Add(category);

            context.SaveChanges();
        }

        public void AddRange(Category[] categories)
        {
            context.Categories.AddRange(categories);

            context.SaveChanges();
        }

        public Category[] GetCategories()
        {
            var models = context.Categories
                .Include(c => c.CategoryProducts)
                .ThenInclude(cp => cp.Product)
                .Where(c => c.CategoryProducts.Count > 0)
                .ToArray();

            return models;
        }
    }
}