using ProductShop.App.Commands.Contracts;
using ProductShop.App.Models;
using ProductShop.Services.Contracts;
using System.Linq;

namespace ProductShop.App.Commands.Export
{
    public class ExportXMLCommand : ICommand
    {
        private readonly string exportFilePath = "../../../../Results/";

        private readonly IUserService userService;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ICategoryProductService categoryProductService;

        private readonly XMLExporter exporter;

        public ExportXMLCommand(string exportFilePath, IUserService userService, IProductService productService, ICategoryService categoryService, ICategoryProductService categoryProductService)
        {
            this.userService = userService;
            this.productService = productService;
            this.categoryService = categoryService;
            this.categoryProductService = categoryProductService;

            this.exporter = new XMLExporter();
        }

        public void Execute()
        {
            ProductInRange();
            SoldProducts();
            CategoriesByProductsCount();
            UsersAndProducts();
        }

        private void UsersAndProducts()
        {
            string filePath = exportFilePath + "users-and-products.xml";

            var users = userService.GetAll()
                .Select(u => new UserAndProductDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    Sold = u.Sold.Select(p => new ProductNameAndPriceDto()
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .OrderByDescending(u => u.Sold.Count())
                .ThenBy(u => u.LastName)
                .ToArray();

            exporter.ExportUsersAndProduts(filePath, users);
        }

        private void CategoriesByProductsCount()
        {
            string filePath = exportFilePath + "categories-by-products.xml";

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
                .OrderByDescending(c => c.ProductsCount)
               .ToArray();

            exporter.ExportCategoriesByProducts(filePath, categoriesDto);
        }

        private void SoldProducts()
        {
            string filePath = exportFilePath + "users-sold-products.xml";

            UserDto[] usersDto = userService.GetAllWith<UserDto>()
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToArray();

            exporter.ExportUserWithSoldProducts(filePath, usersDto);
        }

        private void ProductInRange()
        {
            string filePath = exportFilePath + "products-in-range.xml";

            int min = 1000;
            int max = 2000;

            ProductWithBuyerNamesDto[] productDtos = productService.GetInPriceRange<ProductWithBuyerNamesDto>(min, max).OrderBy(p => p.Price).ToArray();

            exporter.ExportProductWithBuyerFullName(filePath, productDtos);
        }
    }
}