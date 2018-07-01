using P02_DatabaseFirst.Data;
using ResultWriter;
using System;
using System.Linq;

namespace EmployeesFromResearchAndDevelopment
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees
                    .Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(e => e.Salary)
                    .ThenByDescending(e => e.FirstName)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.Department.Name,
                        e.Salary
                    })
                    .ToList();

                foreach (var employee in employees)
                {
                    FileWriter.WriteLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:F2}");
                }
            }
        }
    }
}