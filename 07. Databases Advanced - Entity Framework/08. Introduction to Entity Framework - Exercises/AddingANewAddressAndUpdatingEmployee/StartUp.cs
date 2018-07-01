using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using ResultWriter;
using System;
using System.Linq;

namespace AddingANewAddressAndUpdatingEmployee
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var address = new Address();
                address.AddressText = "Vitoshka 15";
                address.TownId = 4;

                Employee employee = db.Employees.FirstOrDefault(e => e.LastName == "Nakov");
                employee.Address = address;

                db.SaveChanges();

                var employees = db.Employees
                    .OrderByDescending(e => e.AddressId)
                    .Take(10)
                    .Select(e => new
                    {
                        e.Address.AddressText
                    })
                    .ToList();

                foreach (var a in employees)
                {
                    FileWriter.WriteLine(a.AddressText);
                }
            }
        }
    }
}