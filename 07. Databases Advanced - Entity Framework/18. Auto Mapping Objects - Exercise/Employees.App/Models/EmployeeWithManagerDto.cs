using System;

namespace Employees.App.Models
{
    public class EmployeeWithManagerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime Birthday { get; set; }

        public string ManagerLastName { get; set; }

        public override string ToString()
        {
            string managerLastName = ManagerLastName == null ? "[no manager]" : ManagerLastName;
            return $"{FirstName} {LastName} - ${Salary:F2} - Manager: {managerLastName}";
        }
    }
}