using P02_DatabaseFirst.Data;
using System.Linq;
using System;
using ResultWriter;

namespace DepartmentsWithMoreThan5Employees
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var departments = db.Departments
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count)
                    .ThenBy(d => d.Name)
                    .Select(d => new
                    {
                        DepartmentName = d.Name,
                        ManagerName = $"{d.Manager.FirstName} {d.Manager.LastName}",
                        Employees = d.Employees.Select(e => new
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Job = e.JobTitle
                        })
                    })
                    .ToList();

                foreach (var department in departments)
                {
                    FileWriter.WriteLine($"{department.DepartmentName} - {department.ManagerName}");

                    foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                    {
                        FileWriter.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.Job}");
                    }
                    FileWriter.WriteLine("----------");
                }
            }
        }
    }
}