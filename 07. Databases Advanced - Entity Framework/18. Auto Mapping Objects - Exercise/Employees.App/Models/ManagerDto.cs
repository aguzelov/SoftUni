using System.Collections.Generic;
using System.Text;

namespace Employees.App.Models
{
    public class ManagerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDto> ManagerEmployees { get; set; }

        public int ManagerEmployeesCount
        {
            get
            {
                return this.ManagerEmployees.Count;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{FirstName} {LastName} | Employees: {ManagerEmployeesCount}");
            foreach (var emp in ManagerEmployees)
            {
                sb.AppendLine($"    - {emp.FirstName} {emp.LastName} - ${emp.Salary:F2}");
            }

            return sb.ToString().Trim();
        }
    }
}