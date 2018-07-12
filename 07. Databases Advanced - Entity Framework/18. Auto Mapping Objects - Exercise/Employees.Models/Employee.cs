using System;
using System.Collections.Generic;

namespace Employees.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> ManagerEmployees { get; set; } = new List<Employee>();

        public override string ToString()
        {
            return $"ID: {EmployeeId} - {FirstName} {LastName} - ${Salary:f2}{Environment.NewLine}" +
                $"Birthday: {Birthday.ToString("dd-MM-yyyy")}{Environment.NewLine}" +
                $"Address: {Address}";
        }
    }
}