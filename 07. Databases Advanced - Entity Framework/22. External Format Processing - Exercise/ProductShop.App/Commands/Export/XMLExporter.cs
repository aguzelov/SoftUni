using ProductShop.App.Models;
using System.Xml.Linq;

namespace ProductShop.App.Commands.Export
{
    public class XMLExporter
    {
        public void ExportProductWithBuyerFullName(string filePath, ProductWithBuyerNamesDto[] products)
        {
            var xDoc = new XDocument();

            xDoc.Add(new XElement("products"));

            foreach (var product in products)
            {
                var element = new XElement("product",
                    new XAttribute("name", product.Name),
                    new XAttribute("price", product.Price),
                    new XAttribute("buyer", product.BuyerFirstName + " " + product.BuyerLastName)
                    );

                xDoc.Root.Add(element);
            }

            xDoc.Save(filePath);
        }

        public void ExportUserWithSoldProducts(string filePath, UserDto[] users)
        {
            var xDoc = new XDocument();

            xDoc.Add(new XElement("users"));

            foreach (var user in users)
            {
                XElement userElement;

                if (user.FirstName == null)
                {
                    userElement = new XElement("user",
                        new XAttribute("last-name", user.LastName));
                }
                else
                {
                    userElement = new XElement("user",
                         new XAttribute("first-name", user.FirstName),
                         new XAttribute("last-name", user.LastName));
                }

                XElement soldProducts = new XElement("sold-products");

                foreach (var product in user.Sold)
                {
                    var productElement = new XElement("product",
                        new XElement("name", product.Name),
                        new XElement("price", product.Price));

                    soldProducts.Add(productElement);
                }

                userElement.Add(soldProducts);

                xDoc.Root.Add(userElement);
            }

            xDoc.Save(filePath);
        }

        public void ExportCategoriesByProducts(string filePath, CategoryByProductsDto[] categories)
        {
            var xDoc = new XDocument();

            xDoc.Add(new XElement("categories"));

            foreach (var category in categories)
            {
                XElement categoryElement = new XElement("category",
                    new XAttribute("name", category.Category));

                categoryElement.Add(new XElement("products-count", category.ProductsCount),
                                    new XElement("average-price", category.AveragePrice),
                                    new XElement("total-revenue", category.TotalRevenue));

                xDoc.Root.Add(categoryElement);
            }

            xDoc.Save(filePath);
        }

        public void ExportUsersAndProduts(string filePath, UserAndProductDto[] users)
        {
            var xDoc = new XDocument();

            xDoc.Add(new XElement("users",
                new XAttribute("count", users.Length)));

            foreach (var user in users)
            {
                XElement userElement = new XElement("user");

                if (user.FirstName != null)
                {
                    userElement.Add(new XAttribute("first-name", user.FirstName));
                }

                userElement.Add(new XAttribute("last-name", user.LastName));

                if (user.Age != null)
                {
                    userElement.Add(new XAttribute("age", user.Age));
                }

                XElement soldProductsElement = new XElement("sold-products",
                                                             new XAttribute("count", user.Sold.Length));

                foreach (var product in user.Sold)
                {
                    XElement productElement = new XElement("product",
                            new XAttribute("name", product.Name),
                            new XAttribute("price", product.Price));

                    soldProductsElement.Add(productElement);
                }

                userElement.Add(soldProductsElement);
                xDoc.Root.Add(userElement);
            }

            xDoc.Save(filePath);
        }
    }
}