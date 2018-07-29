using ProductShop.Data;
using ProductShop.Models;
using System;
using System.IO;

namespace ProductShop.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShoContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            ImportData(context);
            ExportData(context);
        }

        private static void ImportData(ProductShoContext context, string baseDir = @"..\..\..\Resources\")
        {
            User[] users = DataProcessor.Deserializer.ImportUsers(context, File.ReadAllText(baseDir + "users.xml"));

            Product[] products = DataProcessor.Deserializer.ImportProducts(context, users, File.ReadAllText(baseDir + "products.xml"));

            Category[] categories = DataProcessor.Deserializer.ImportCategories(context, File.ReadAllText(baseDir + "categories.xml"));

            CategoryProducts[] categoryProducts = GenerateCategoryProducts(products, categories);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        private static void ExportData(ProductShoContext context, string baseDir = @"..\..\..\Results\")
        {
            string productsInRangeString = DataProcessor.Serializer.ProductsInRange(context, 1000, 2000);
            File.WriteAllText(baseDir + "products-in-range.xml", productsInRangeString);

            string usersSoldProducts = DataProcessor.Serializer.UsersSoldProducts(context);
            File.WriteAllText(baseDir + "users-sold-products.xml", usersSoldProducts);

            string categoriesByProductsCountString = DataProcessor.Serializer.CategoriesByProductsCount(context);
            File.WriteAllText(baseDir + "categories-by-products.xml",
                categoriesByProductsCountString);

            string usersAndProducts = DataProcessor.Serializer.UsersAndProducts(context);
            File.WriteAllText(baseDir + "users-and-products.xml", usersAndProducts);
        }

        private static CategoryProducts[] GenerateCategoryProducts(Product[] products, Category[] categories)
        {
            CategoryProducts[] categoryProducts = new CategoryProducts[products.Length];

            Random random = new Random();

            for (int i = 0; i < categoryProducts.Length; i++)
            {
                CategoryProducts categoryProduct = new CategoryProducts
                {
                    Product = products[i],
                    Category = categories[random.Next(categories.Length - 1)]
                };

                categoryProducts[i] = categoryProduct;
            }

            return categoryProducts;
        }
    }
}