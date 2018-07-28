using FastFood.Data;
using FastFood.Models.Enums;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace FastFood.DataProcessor
{
    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            OrderType type = (OrderType)Enum.Parse(typeof(OrderType), orderType);

            var orders = context.Employees
                .Where(e => e.Name == employeeName)
                .Select(e => new OrderExportDto
                {
                    Name = e.Name,
                    Orders = e.Orders
                    .Where(o => o.Type == type)
                    .Select(o => new OrderItemsExportDto
                    {
                        Customer = o.Customer,
                        Items = o.OrderItems
                        .Select(oi => new ItemExportDto
                        {
                            Name = oi.Item.Name,
                            Price = oi.Item.Price,
                            Quantity = oi.Quantity
                        }).ToArray()
                    })
                    .OrderByDescending(o => o.TotalPrice)
                    .ThenByDescending(o => o.Items.Length)
                    .ToArray()
                })
                .SingleOrDefault();

            var jsonString = JsonConvert.SerializeObject(orders, Newtonsoft.Json.Formatting.Indented);

            return jsonString;
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            var categories = categoriesString.Split(',');

            var categoryStatistics = context.Items
                .Where(i => categories.Any(c => c == i.Category.Name))
                .GroupBy(i => i.Category.Name)
                .Select(g => new CategoryDto
                {
                    Name = g.Key,
                    MostPopularItem = g.Select(i => new ItemExportXmlDto
                    {
                        Name = i.Name,
                        TotalMade = i.OrderItems.Sum(oi => oi.Quantity * oi.Item.Price),
                        TimesSold = i.OrderItems.Sum(oi => oi.Quantity)
                    })
                        .OrderByDescending(i => i.TotalMade)
                        .ThenByDescending(i => i.TimesSold)
                        .First()
                })
                .OrderByDescending(dto => dto.MostPopularItem.TotalMade)
                .ThenByDescending(dto => dto.MostPopularItem.TimesSold)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            serializer.Serialize(new StringWriter(sb), categoryStatistics, namespaces);

            var result = sb.ToString();

            return result;
        }
    }
}