using ProductShop.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ProductShop.App.Commands.Import
{
    public class XMLImporter
    {
        public User[] DeserializeUser(string path)
        {
            var xmlDoc = XDocument.Load(path);
            var users = new List<User>();

            foreach (var element in xmlDoc.Root.Elements())
            {
                var firstName = element?.Attribute("firstName")?.Value;
                var lastName = element?.Attribute("lastName")?.Value;
                var ageStr = element?.Attribute("age")?.Value;

                if (lastName == null)
                {
                    continue;
                }

                var user = new User();
                user.FirstName = firstName;
                user.LastName = lastName;

                int age;
                bool isValidAge = int.TryParse(ageStr, out age);
                if (isValidAge)
                {
                    user.Age = age;
                }

                users.Add(user);
            }

            return users.ToArray();
        }

        public Product[] DeserializeProduct(string path)
        {
            var xmlDoc = XDocument.Load(path);
            var products = new List<Product>();

            foreach (var element in xmlDoc.Root.Elements())
            {
                var name = element?.Element("name")?.Value;
                var priceStr = element?.Element("price")?.Value;

                if (name == null)
                {
                    continue;
                }

                var product = new Product();
                product.Name = name;

                decimal price;
                bool isValidPrice = decimal.TryParse(priceStr, out price);
                if (isValidPrice)
                {
                    product.Price = price;
                }

                products.Add(product);
            }

            return products.ToArray();
        }

        public Category[] DeserializeCategory(string path)
        {
            var xmlDoc = XDocument.Load(path);
            var categories = new List<Category>();

            foreach (var element in xmlDoc.Root.Elements())
            {
                var name = element?.Element("name")?.Value;

                if (name == null)
                {
                    continue;
                }

                var category = new Category()
                {
                    Name = name
                };

                categories.Add(category);
            }

            return categories.ToArray();
        }
    }
}