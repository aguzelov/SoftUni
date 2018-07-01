using P02_DatabaseFirst.Data;
using ResultWriter;
using System;
using System.Linq;

namespace EmployeesByFirstNameStartingWithSa
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees
                    .Where(e => e.FirstName.StartsWith("Sa"))
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle,
                        e.Salary
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList();

                employees.ForEach(e => FileWriter.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})"));
            }
        }
    }
}