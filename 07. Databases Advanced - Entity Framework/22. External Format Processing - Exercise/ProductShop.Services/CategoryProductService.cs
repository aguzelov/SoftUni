using ProductShop.Data;
using ProductShop.Models;
using ProductShop.Services.Contracts;

namespace ProductShop.Services
{
    public class CategoryProductService : ICategoryProductService
    {
        private readonly ProductShopContext context;

        public CategoryProductService(ProductShopContext context)
        {
            this.context = context;
        }

        public void AddCategoryProduct(CategoryProduct categoryProduct)
        {
            context.CategoryProducts.Add(categoryProduct);

            context.SaveChanges();
        }

        public void AddRange(CategoryProduct[] categoryProducts)
        {
            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();
        }
    }
}