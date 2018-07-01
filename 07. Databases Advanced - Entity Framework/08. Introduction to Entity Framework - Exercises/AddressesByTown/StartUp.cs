using P02_DatabaseFirst.Data;
using ResultWriter;
using System;
using System.Linq;

namespace AddressesByTown
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var addresses = db.Addresses
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.AddressText)
                    .Take(10)
                    .Select(a => new
                    {
                        AddressText = a.AddressText,
                        TownName = a.Town.Name,
                        EmployeeCount = a.Employees.Count
                    })
                    .ToList();

                foreach (var address in addresses)
                {
                    FileWriter.WriteLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
                }
            }
        }
    }
}