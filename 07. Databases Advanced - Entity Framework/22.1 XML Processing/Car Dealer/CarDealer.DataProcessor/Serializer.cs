using CarDealer.Data;
using CarDealer.DataProcessor.Models.Export;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer.DataProcessor
{
    public static class Serializer
    {
        public static string CarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new CarWithDistanceExportDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    Distance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CarWithDistanceExportDto[]), new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            var result = sb.ToString();
            return result;
        }

        public static string CarsFromMakeFerrari(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Ferrari")
                .Select(c => new CarsFromMakeFerrariExportDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    Distance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.Distance)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CarsFromMakeFerrariExportDto[]), new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            var result = sb.ToString();

            return result;
        }

        public static string LocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSupplierExportDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Count = s.Parts.Count()
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(LocalSupplierExportDto[]), new XmlRootAttribute("suppliers"));

            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            var result = sb.ToString();

            return result;
        }

        public static string CarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarsAndTheirPartsExportDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    Distance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(p => new PartsForCarExportDto
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .ToArray()
                }).ToArray();

            var serializer = new XmlSerializer(typeof(CarsAndTheirPartsExportDto[]), new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            var result = sb.ToString();

            return result;
        }

        public static string TotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new TotalSalesByCustomerExportDto
                {
                    FullName = c.Name,
                    CatsCount = c.Sales.Count(),
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
                .ThenByDescending(c => c.CatsCount)
                .ToArray();

            var serializer = new XmlSerializer(typeof(TotalSalesByCustomerExportDto[]), new XmlRootAttribute("customers"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            var result = sb.ToString();

            return result;
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
                        Distance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Dicount = ((decimal)s.Discount / 100).ToString(),
                    Price = s.Car.PartCars.Sum(p => p.Part.Price * p.Part.Quantity),
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(SalesWithAppliedDiscountExportDto[]), new XmlRootAttribute("sales"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), sales, namespaces);

            var result = sb.ToString();

            return result;
        }
    }
}