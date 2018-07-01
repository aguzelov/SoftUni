using P02_DatabaseFirst.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using ResultWriter;

namespace IncreaseSalaries
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var departmentsToBeIncrease = new List<string> { "Engineering", "Tool Design", "Marketing", "Information Services" };

            using (var db = new SoftUniContext())
            {
                var employees = db.Employees
                    .Where(e => departmentsToBeIncrease.Contains(e.Department.Name))
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList();

                employees.ForEach(e => e.Salary *= 1.12m);

                db.SaveChanges();

                employees.ForEach(e => FileWriter.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})"));
            }
        }
    }
}