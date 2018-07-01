using P02_DatabaseFirst.Data;
using System.Linq;
using System;
using System.Globalization;
using ResultWriter;

namespace FindLatest10Projects
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var projects = db.Projects
                    .OrderByDescending(p => p.StartDate)
                    .Take(10)
                    .Select(p => new
                    {
                        p.Name,
                        p.Description,
                        StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                    })
                    .ToList();

                foreach (var project in projects.OrderBy(p => p.Name))
                {
                    FileWriter.WriteLine(project.Name);
                    FileWriter.WriteLine(project.Description);
                    FileWriter.WriteLine(project.StartDate);
                }
            }
        }
    }
}