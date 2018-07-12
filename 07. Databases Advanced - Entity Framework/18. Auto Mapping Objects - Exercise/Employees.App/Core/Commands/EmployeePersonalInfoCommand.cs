using Employees.App.Core.Commands.Contracts;
using Employees.App.Core.IO.Contracts;
using Employees.Models;
using Employees.Services.Contracts;
using System;

namespace Employees.App.Core.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly IEmployeeService employeeService;
        private readonly IOutputWriter writer;

        public EmployeePersonalInfoCommand(IEmployeeService employeeService, IOutputWriter writer)
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

            int employeeId = int.Parse(data[0]);

            Employee employee = this.employeeService.GetEmploye<Employee>(employeeId);

            writer.WriteLine(employee.ToString());
        }
    }
}