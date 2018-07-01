using P02_DatabaseFirst.Data;
using System.Linq;
using System;
using ResultWriter;

namespace RemoveTowns
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string townName = Console.ReadLine();

            using (var db = new SoftUniContext())
            {
                var town = db.Towns
                    .Where(t => t.Name == townName)
                    .SingleOrDefault();

                var addresses = db.Addresses.Where(a => a.TownId == town.TownId).ToList();

                var addressesCount = addresses.Count;

                var employees = db.Employees.Where(a => addresses.Contains(a.Address)).ToList();
                employees.ForEach(e => e.AddressId = null);

                db.Addresses.RemoveRange(addresses);
                db.Towns.Remove(town);

                FileWriter.WriteLine($"{addressesCount} address in Sofia was deleted");
            }
        }
    }
}