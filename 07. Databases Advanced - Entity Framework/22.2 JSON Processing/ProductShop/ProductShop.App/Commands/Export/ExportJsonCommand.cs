using ProductShop.App.Commands.Contracts;
using ProductShop.App.Models;
using ProductShop.Services.Contracts;
using System.Linq;

namespace ProductShop.App.Commands.Export
{
    public class ExportJsonCommand : ICommand
    {
        private readonly string exportFilePath = "../../../../Results/";

        private readonly IUserService userService;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ICategoryProductService categoryProductService;

        private readonly IExporter exporter;

        public ExportJsonCommand(IUserService userService, IProductService productService, ICategoryService categoryService, ICategoryProductService categoryProductService)
        {
            this.userService = userService;
            this.productService = productService;
            this.categoryService = categoryService;
            this.categoryProductService = categoryProductService;

            this.exporter = new JsonExporter();
        }

        public void Execute()
        {
            ProductInRange();
            SuccessfullySoldProducts();
            CategoriesByProductsCount();
            UsersAndProducts();
        }

        private void UsersAndProducts()
        {
            string filePath = exportFilePath + "users-and-products.json";

            var users = userService.GetAll()
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.Sold.Count(),
                        products = u.Sold.Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                    }
                })
                .OrderByDescending(u => u.soldProducts.count)
                .ThenBy(u => u.lastName)
                .ToArray();

            var jsonstring = new
            {
                userCount = users.Length,
                users
            };

            exporter.Export(filePath, jsonstring);
        }

        private void CategoriesByProductsCount()
        {
            string filePath = exportFilePath + "categories-by-products.json";

            var categoriesDto = categoryService.GetCategories()
                .Select(c => new CategoryByProductsDto()
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts
                                .Select(cp => cp.Product.Price)
                                .Average(),
                    TotalRevenue = c.CategoryProducts
                                .Select(cp => cp.Product.Price)
                                .Sum()
                })
               .ToArray();

            exporter.Export<CategoryByProductsDto>(filePath, categoriesDto);
        }

        private void SuccessfullySoldProducts()
        {
            string filePath = exportFilePath + "users-sold-products.json";

            UserDto[] usersDto = userService.GetAllWith<UserDto>()
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToArray();

            exporter.Export<UserDto>(filePath, usersDto);
        }

        private void ProductInRange()
        {
            string filePath = exportFilePath + "products-in-range.json";

            int min = 500;
            int max = 1000;

            ProductWithSellerNamesDto[] productDtos = productService
                .GetInPriceRange<ProductWithSellerNamesDto>(min, max)
                .OrderBy(p => p.Price)
                .ToArray();

            exporter.Export<ProductWithSellerNamesDto>(filePath, productDtos);
        }
    }
}