using ProductShop.App.Commands.Contracts;
using ProductShop.Models;
using ProductShop.Services.Contracts;
using System;

namespace ProductShop.App.Commands.Import
{
    public class ImportJsonCommand : ICommand
    {
        private readonly string importFilePath = "../../../../Resources/";

        private readonly IUserService userService;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ICategoryProductService categoryProductService;
        private readonly IImporter importer;

        public ImportJsonCommand(IUserService userService, IProductService productService, ICategoryService categoryService, ICategoryProductService categoryProductService)
        {
            this.userService = userService;
            this.productService = productService;
            this.categoryService = categoryService;
            this.categoryProductService = categoryProductService;
            this.importer = new JsonImporter();
        }

        public void Execute()
        {
            User[] users = ImportUsers();

            Product[] products = ImportProducts(users);

            Category[] categories = ImportCategories();

            ImportCategoryProducts(products, categories);
        }

        private void ImportCategoryProducts(Product[] products, Category[] categories)
        {
            int length = products.Length;
            CategoryProduct[] categoryProducts = new CategoryProduct[length];

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int categoryIndex = random.Next(0, categories.Length - 1);

                categoryProducts[i] = new CategoryProduct
                {
                    Product = products[i],
                    Category = categories[categoryIndex]
                };
            }

            categoryProductService.AddRange(categoryProducts);
        }

        private Category[] ImportCategories()
        {
            string path = importFilePath + "categories.json";

            Category[] categories = importer.Deserialize<Category>(path);

            categoryService.AddRange(categories);

            return categories;
        }

        private Product[] ImportProducts(User[] users)
        {
            string path = importFilePath + "products.json";
            Product[] products = importer.Deserialize<Product>(path);

            Random random = new Random();

            foreach (var product in products)
            {
                product.Seller = users[random.Next(0, users.Length - 1)];

                int userIndex = random.Next(0, users.Length - 1);
                if (userIndex <= users.Length * 0.75)
                {
                    product.Buyer = users[userIndex];
                }
            }

            productService.AddRange(products);

            return products;
        }

        private User[] ImportUsers()
        {
            string path = importFilePath + "users.json";

            User[] users = importer.Deserialize<User>(path);

            userService.AddRange(users);

            return users;
        }
    }
}