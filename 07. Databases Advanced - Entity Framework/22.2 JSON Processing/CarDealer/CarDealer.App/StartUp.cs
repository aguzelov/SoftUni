using CarDealer.Data;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarDealer.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            ImportData(context);
            ExportData(context);
        }

        private static void ExportData(CarDealerContext context, string baseDir = @"..\..\..\Results\")
        {
            var orderedCustomersString = DataProcessor.Serializer.OrderedCustomers(context);
            File.WriteAllText(baseDir + "ordered-customers.json", orderedCustomersString);

            var carsFromMakeToyotaString = DataProcessor.Serializer.CarsFromMakeToyota(context);
            File.WriteAllText(baseDir + "toyota-cars.json", carsFromMakeToyotaString);

            var localSuppliersString = DataProcessor.Serializer.LocalSuppliers(context);
            File.WriteAllText(baseDir + "local-suppliers.json", localSuppliersString);

            var carsWithTheirListOfPartsString = DataProcessor.Serializer.CarsWithTheirListOfParts(context);
            File.WriteAllText(baseDir + "cars-and-parts.json", carsWithTheirListOfPartsString);

            var totalSalesByCustomerString = DataProcessor.Serializer.TotalSalesByCustomer(context);
            File.WriteAllText(baseDir + "customers-total-sales.json", totalSalesByCustomerString);

            var salesWithAppliedDiscountString = DataProcessor.Serializer.SalesWithAppliedDiscount(context);
            File.WriteAllText(baseDir + "sales-discounts.json", salesWithAppliedDiscountString);
        }

        private static void ImportData(CarDealerContext context, string baseDir = @"..\..\..\Resources\")
        {
            var suppliers = DataProcessor.Deserializer.ImportSuppliers(File.ReadAllText(baseDir + "suppliers.json"));

            var parts = DataProcessor.Deserializer.ImportParts(suppliers.ToArray(), File.ReadAllText(baseDir + "parts.json"));

            var cars = DataProcessor.Deserializer.ImportCars(parts, File.ReadAllText(baseDir + "cars.json"));

            var customers = DataProcessor.Deserializer.ImportCustomer(File.ReadAllText(baseDir + "customers.json"));

            var sales = GenerateSales(cars, customers);

            context.Sales.AddRange(sales);
            context.SaveChanges();
        }

        private static ICollection<Sale> GenerateSales(ICollection<Car> cars, ICollection<Customer> customers)
        {
            var sales = new Sale[cars.Count];

            Random random = new Random();

            for (int i = 0; i < sales.Length; i++)
            {
                Customer customer = customers.ElementAt(random.Next(customers.Count - 1));

                int discount = GetDiscount(customer.IsYoungDriver);

                sales[i] = new Sale
                {
                    Car = cars.ElementAt(i),
                    Customer = customer,
                    Discount = discount
                };
            }

            return sales;
        }

        private static int GetDiscount(bool isYoungDriver)
        {
            var discounts = new int[] { 0, 5, 10, 15, 20, 30, 40, 50 };

            Random random = new Random();

            int discount = discounts[random.Next(0, discounts.Length - 1)];
            if (isYoungDriver)
            {
                discount += 5;
            }

            return discount;
        }
    }
}