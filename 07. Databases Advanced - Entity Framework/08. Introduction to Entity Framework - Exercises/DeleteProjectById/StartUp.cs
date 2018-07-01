using P02_DatabaseFirst.Data;
using System.Linq;
using System;
using ResultWriter;

namespace DeleteProjectById
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var projectToBeDeleted = db.Projects.FirstOrDefault(p => p.ProjectId == 2);

                db.RemoveRange(db.EmployeesProjects
                    .Where(ep => ep.ProjectId == 2));
                db.Remove(projectToBeDeleted);
                db.SaveChanges();

                db.Projects
                    .Select(p => p.Name)
                    .Take(10)
                    .ToList()
                    .ForEach(p => FileWriter.WriteLine($"{p}"));
            }
        }
    }
}