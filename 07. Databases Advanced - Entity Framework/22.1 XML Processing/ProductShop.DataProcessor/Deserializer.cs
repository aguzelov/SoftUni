using ProductShop.Data;
using ProductShop.DataProcessor.Models.Import;
using ProductShop.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DataProcessor
{
    public static class Deserializer
    {
        public static User[] ImportUsers(ProductShoContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(UserImportDto[]), new XmlRootAttribute("users"));

            var userDtos = (UserImportDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            User[] users = new User[userDtos.Length];
            for (int i = 0; i < users.Length; i++)
            {
                users[i] = new User
                {
                    FirstName = userDtos[i].FirstName,
                    LastName = userDtos[i].LastName,
                    Age = userDtos[i].Age,
                };
            }

            return users;
        }

        public static Product[] ImportProducts(ProductShoContext context, User[] users, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ProductImportDto[]), new XmlRootAttribute("products"));

            var productDtos = (ProductImportDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            Random random = new Random();

            Product[] products = new Product[productDtos.Length];
            for (int i = 0; i < productDtos.Length; i++)
            {
                products[i] = new Product
                {
                    Name = productDtos[i].Name,
                    Price = productDtos[i].Price,
                };

                products[i].Seller = users[random.Next(users.Length - 1)];
                int buyerIndex = random.Next(users.Length * 2);
                if (buyerIndex >= users.Length)
                {
                    products[i].Buyer = null;
                }
                else
                {
                    products[i].Buyer = users[buyerIndex];
                }
            }

            return products;
        }

        public static Category[] ImportCategories(ProductShoContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(CategoryImportDto[]), new XmlRootAttribute("categories"));

            var categoryDtos = (CategoryImportDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            Category[] categories = categoryDtos
                .Select(c => new Category
                {
                    Name = c.Name
                })
                .ToArray();

            return categories;
        }
    }
}