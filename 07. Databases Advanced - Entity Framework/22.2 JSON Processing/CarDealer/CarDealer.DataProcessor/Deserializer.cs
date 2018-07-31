using CarDealer.DataProcessor.Models.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.DataProcessor
{
    public static class Deserializer
    {
        public static ICollection<Supplier> ImportSuppliers(string jsonString)
        {
            var supplierDtos = JsonConvert.DeserializeObject<SupplierImportDto[]>(jsonString);

            var suppliers = new List<Supplier>();

            foreach (var supplier in supplierDtos)
            {
                suppliers.Add(new Supplier
                {
                    Name = supplier.Name,
                    IsImporter = supplier.IsImporter
                });
            }

            return suppliers;
        }

        public static ICollection<Part> ImportParts(Supplier[] suppliers, string jsonString)
        {
            var partDtos = JsonConvert.DeserializeObject<PartImportDto[]>(jsonString);

            var parts = new List<Part>();

            Random random = new Random();
            foreach (var dto in partDtos)
            {
                parts.Add(new Part
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    Supplier = suppliers[random.Next(suppliers.Length - 1)]
                });
            }

            return parts;
        }

        public static ICollection<Car> ImportCars(ICollection<Part> parts, string jsonString)
        {
            var carDtos = JsonConvert.DeserializeObject<CarImportDto[]>(jsonString);

            var cars = new List<Car>();

            foreach (var dto in carDtos)
            {
                cars.Add(new Car
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TravelledDistance = dto.TravelledDistance,
                });
            }

            cars = AddPartsToCars(parts, cars).ToList();

            return cars;
        }

        public static ICollection<Customer> ImportCustomer(string jsonString)
        {
            var customerDtos = JsonConvert.DeserializeObject<CustomerImportDto[]>(jsonString);

            var customers = new List<Customer>();

            foreach (var dto in customerDtos)
            {
                bool isParset = DateTime.TryParse(dto.BirthDate, out DateTime dateTime);

                customers.Add(new Customer
                {
                    Name = dto.Name,
                    BirthDate = dateTime,
                    IsYoungDriver = dto.IsYoungDriver
                });
            }

            return customers;
        }

        private static ICollection<Car> AddPartsToCars(ICollection<Part> parts, ICollection<Car> cars)
        {
            Random random = new Random();
            foreach (Car car in cars)
            {
                car.PartCars = GeneratePartCars(parts, random.Next(10, 20));
            }

            return cars;
        }

        private static ICollection<PartCar> GeneratePartCars(ICollection<Part> parts, int count)
        {
            var rangeOfParts = new List<Part>();
            Random random = new Random();

            while (rangeOfParts.Count < count)
            {
                rangeOfParts.Add(parts.ElementAt(random.Next(0, parts.Count - 1)));

                if (rangeOfParts.Count == count)
                {
                    rangeOfParts = rangeOfParts.Distinct().ToList();
                }
            }

            var partCars = new List<PartCar>();
            foreach (var part in rangeOfParts)
            {
                partCars.Add(new PartCar
                {
                    Part = part
                });
            }

            return partCars;
        }
    }
}