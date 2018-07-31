using ProductShop.Models;

namespace ProductShop.Services.Contracts
{
    public interface ICategoryProductService
    {
        void AddCategoryProduct(CategoryProduct categoryProduct);

        void AddRange(CategoryProduct[] categoryProducts);
    }
}