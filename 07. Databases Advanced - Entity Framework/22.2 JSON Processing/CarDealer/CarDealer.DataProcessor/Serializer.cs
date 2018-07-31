using CarDealer.Data;
using CarDealer.DataProcessor.Models.Export;
using Newtonsoft.Json;
using System.Linq;

namespace CarDealer.DataProcessor
{
    public static class Serializer
    {
        public static string OrderedCustomers(CarDealerContext context)
        {
            var cars = context.Customers
                .Select(c => new CustomerExportDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ToArray();

            var carsString = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return carsString;
        }

        public static string CarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new CarsFromMakeToyotaExportDto
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            var carsString = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return carsString;
        }

        public static string LocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSupplierExportDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            var suppliersString = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return suppliersString;
        }

        public static string CarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarsAndTheirPartsExportDto
                {
                    Car = new CarWithDistanceExportDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance,
                    },
                    Parts = c.PartCars
                        .Select(p => new PartsForCarExportDto
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .ToArray()
                }).ToArray();

            var carsString = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return carsString;
        }

        public static string TotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new TotalSalesByCustomerExportDto
                {
                    FullName = c.Name,
                    CarsCount = c.Sales.Count(),
                    PriceAndDiscounts = c.Sales
                        .Select(s => new CarPriceAndDiscountExportDto
                        {
                            TotalPrice = s.Car
                                        .PartCars
                                        .Sum(p =>
                                            p.Part.Price * p.Part.Quantity),
                            Discount = (double)s.Discount / 100
                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.MoneySpent)
                .ThenByDescending(c => c.CarsCount)
                .ToArray();

            var customersString = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersString;
        }

        public static string SalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SalesWithAppliedDiscountExportDto
                {
                    Car = new CarAndDistanceAttributeExportDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = ((decimal)s.Discount / 100).ToString(),
                    Price = s.Car.PartCars.Sum(p => p.Part.Price * p.Part.Quantity),
                })
                .ToArray();

            var salesString = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return salesString;
        }
    }
}