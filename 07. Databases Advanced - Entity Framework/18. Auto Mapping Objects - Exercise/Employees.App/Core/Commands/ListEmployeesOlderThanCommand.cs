using Employees.App.Core.Commands.Contracts;
using Employees.App.Core.IO.Contracts;
using Employees.App.Models;
using Employees.Services.Contracts;
using System;
using System.Linq;

namespace Employees.App.Core.Commands
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly IEmployeeService employeeService;
        private readonly IOutputWriter writer;

        public ListEmployeesOlderThanCommand(IEmployeeService employeeService, IOutputWriter writer)
        {
            this.employeeService = employeeService;
            this.writer = writer;
        }

        public void Execute(string[] data)
        {
            if (data.Length != 1)
            {
                throw new ArgumentException("Invalid command!");
            }

            int age = int.Parse(data[0]);

            var employees = this.employeeService.All<EmployeeWithManagerDto>()
                .Where(e => (e.Birthday.AddYears(age)).Year < DateTime.Now.Year)
                .ToArray()
                .OrderByDescending(e => e.Salary);

            foreach (var employee in employees)
            {
                writer.WriteLine(employee.ToString());
            }
        }
    }
}