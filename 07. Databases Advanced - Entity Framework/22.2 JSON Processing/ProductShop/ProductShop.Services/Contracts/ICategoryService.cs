using ProductShop.Models;

namespace ProductShop.Services.Contracts
{
    public interface ICategoryService
    {
        void AddCategory(Category category);

        void AddRange(Category[] categories);

        Category[] GetCategories();
    }
}