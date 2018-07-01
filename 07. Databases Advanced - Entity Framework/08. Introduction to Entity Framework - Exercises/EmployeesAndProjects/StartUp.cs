using P02_DatabaseFirst.Data;
using ResultWriter;
using System;
using System.Globalization;
using System.Linq;

namespace EmployeesAndProjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees
                    .Where(e => e.EmployeesProjects.Any(
                        ep => ep.Project.StartDate.Year >= 2001 &&
                        ep.Project.StartDate.Year <= 2003))
                    .Take(30)
                    .Select(e => new
                    {
                        EmployeeName = $"{e.FirstName} {e.LastName}",
                        ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                        Projects = e.EmployeesProjects.Select(ep => new
                        {
                            ep.Project.Name,
                            ep.Project.StartDate,
                            ep.Project.EndDate
                        })
                    })
                    .ToList();

                foreach (var employee in employees)
                {
                    FileWriter.WriteLine($"{employee.EmployeeName} - Manager: {employee.ManagerName}");
                    foreach (var project in employee.Projects)
                    {
                        string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                        string endDate = project.EndDate == null ? "not finished" : project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                        FileWriter.WriteLine($"--{project.Name} - {startDate} - {endDate}");
                    }
                }
            }
        }
    }
}