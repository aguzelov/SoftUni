using P02_DatabaseFirst.Data;
using ResultWriter;
using System;
using System.Linq;

namespace EmployeesWithSalaryOver50000
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees
                    .Where(e => e.Salary > 50000)
                    .Select(e => new
                    {
                        e.FirstName
                    })
                    .OrderBy(e => e.FirstName)
                    .ToList();

                foreach (var employee in employees)
                {
                    FileWriter.WriteLine(employee.FirstName);
                }
            }
        }
    }
}