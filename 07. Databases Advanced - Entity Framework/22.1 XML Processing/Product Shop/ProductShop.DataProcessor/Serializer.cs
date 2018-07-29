using ProductShop.Data;
using ProductShop.DataProcessor.Models.Export;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop.DataProcessor
{
    public static class Serializer
    {
        public static string ProductsInRange(ProductShoContext context, decimal minPrice, decimal maxPrace)
        {
            var products = context.Products
                .Where(p =>
                p.Price >= minPrice &&
                p.Price <= maxPrace &&
                p.Buyer != null
                )
                .Select(p => new ProductInRangeExportDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFullName = (p.Buyer.FirstName ?? string.Empty) + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ProductInRangeExportDto[]), new XmlRootAttribute("products"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), products, namespaces);

            var result = sb.ToString();

            return result;
        }

        public static string UsersSoldProducts(ProductShoContext context)
        {
            var usersSoldProductsDtos = context.Users
                 .Where(u => u.Sold.Count > 0)
                 .Select(u => new UserSoldProductExportDto
                 {
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     SoldProducts = u.Sold
                         .Select(s => new ProductExportDto
                         {
                             Name = s.Name,
                             Price = s.Price
                         })
                         .ToArray()
                 })
                 .ToArray();

            var serializer = new XmlSerializer(typeof(UserSoldProductExportDto[]), new XmlRootAttribute("users"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), usersSoldProductsDtos, namespaces);

            var result = sb.ToString();

            return result;
        }

        public static string CategoriesByProductsCount(ProductShoContext context)
        {
            var categories = context.Categories
                .Select(c => new CategoriesByProductCountExportDto
                {
                    Name = c.Name,
                    ProductCount = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts
                    .Where(cp => cp.Product.Buyer != null)
                    .Sum(cp => cp.Product.Price)
                })
                .OrderBy(c => c.ProductCount)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CategoriesByProductCountExportDto[]), new XmlRootAttribute("categories"));

            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), categories, namespaces);

            var result = sb.ToString();

            return result;
        }

        public static string UsersAndProducts(ProductShoContext context)
        {
            var usersQuery = context.Users.Where(uc => uc.Sold.Count > 0);

            var users = new UserExportDto
            {
                Count = usersQuery.Count(),
                Users = usersQuery
                    .Select(uc => new UserAndProductsDto
                    {
                        FirstName = uc.FirstName,
                        LastName = uc.LastName,
                        Age = uc.Age,
                        SoldProducts = new SoldProductsExportDto
                        {
                            Count = uc.Sold.Count,
                            Products = uc.Sold
                                .Select(sp => new ProductByUserExportDto
                                {
                                    Name = sp.Name,
                                    Price = sp.Price
                                })
                                .ToArray()
                        }
                    })
                    .ToArray(),
            };

            var serializer = new XmlSerializer(typeof(UserExportDto));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), users, namespaces);

            var result = sb.ToString();

            return result;
        }
    }
}