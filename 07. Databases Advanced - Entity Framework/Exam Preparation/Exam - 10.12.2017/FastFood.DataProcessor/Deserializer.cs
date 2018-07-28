using FastFood.Data;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FastFood.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";
        private const string SuccessMessageOrder = "Order for {0} on {1} added";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var employees = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

            var sb = new StringBuilder();

            var validEmpoyees = new List<Employee>();
            foreach (var dto in employees)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Position position = FindOrCreatePosition(context, dto.Position);

                var employee = new Employee
                {
                    Name = dto.Name,
                    Age = dto.Age,
                    Position = position
                };

                validEmpoyees.Add(employee);

                sb.AppendLine(String.Format(SuccessMessage, employee.Name));
            }

            context.Employees.AddRange(validEmpoyees);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var items = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            var sb = new StringBuilder();
            var validItems = new List<Item>();
            foreach (var dto in items)
            {
                if (!IsValid(dto) ||
                    validItems.Any(i => i.Name == dto.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Category category = FindOrCreateCategory(context, dto.Category);

                Item item = new Item
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Category = category
                };

                validItems.Add(item);

                sb.AppendLine(String.Format(SuccessMessage, item.Name));
            }

            context.Items.AddRange(validItems);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));
            var orders = (OrderDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();
            var validOrders = new List<Order>();

            foreach (var dto in orders)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Employee employee = FindEmployee(context, dto.Employee);

                if (employee == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool itemExist = true;
                var orderItems = new List<OrderItem>();
                foreach (var orderItemDto in dto.Items)
                {
                    Item item = FindItem(context, orderItemDto.Name);
                    if (item == null)
                    {
                        itemExist = false;
                        break;
                    }

                    var orderItem = new OrderItem
                    {
                        Item = item,
                        Quantity = orderItemDto.Quantity
                    };

                    orderItems.Add(orderItem);
                }

                if (!itemExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool isValidDate = DateTime.TryParseExact(dto.DateTime,
                    "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime dateTime);

                OrderType orderType = (OrderType)Enum.Parse(typeof(OrderType), dto.Type);

                var order = new Order
                {
                    Customer = dto.Customer,
                    Employee = employee,
                    DateTime = dateTime,
                    Type = orderType,
                    OrderItems = orderItems
                };

                validOrders.Add(order);

                sb.AppendLine(String.Format(SuccessMessageOrder, order.Customer, order.DateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
            }

            context.Orders.AddRange(validOrders);
            context.SaveChanges();

            string result = sb.ToString().Trim();
            return result;
        }

        private static Item FindItem(FastFoodDbContext context, string itemName)
        {
            Item item = context.Items.SingleOrDefault(i => i.Name == itemName);

            return item;
        }

        private static Employee FindEmployee(FastFoodDbContext context, string employeeName)
        {
            Employee employee = context.Employees.SingleOrDefault(e => e.Name == employeeName);

            return employee;
        }

        private static Category FindOrCreateCategory(FastFoodDbContext context, string categoryName)
        {
            Category category = context.Categories.SingleOrDefault(c => c.Name == categoryName);

            if (category == null)
            {
                category = new Category { Name = categoryName };

                context.Categories.Add(category);
                context.SaveChanges();
            }

            return category;
        }

        private static Position FindOrCreatePosition(FastFoodDbContext context, string positionName)
        {
            Position position = context.Positions.SingleOrDefault(p => p.Name == positionName);

            if (position == null)
            {
                position = new Position
                {
                    Name = positionName
                };

                context.Positions.Add(position);
                context.SaveChanges();
            }

            return position;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);

            return isValid;
        }
    }
}