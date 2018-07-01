using P02_DatabaseFirst.Data;
using ResultWriter;
using System;
using System.Linq;

namespace Employee147
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var employee = db.Employees
                    .Where(e => e.EmployeeId == 147)
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        Job = e.JobTitle,
                        Project = e.EmployeesProjects.Select(ep => new
                        {
                            ep.Project.Name
                        })
                    })
                    .SingleOrDefault();

                FileWriter.WriteLine($"{employee.Name} - {employee.Job}");

                foreach (var project in employee.Project.OrderBy(p => p.Name))
                {
                    FileWriter.WriteLine($"{project.Name}");
                }
            }
        }
    }
}