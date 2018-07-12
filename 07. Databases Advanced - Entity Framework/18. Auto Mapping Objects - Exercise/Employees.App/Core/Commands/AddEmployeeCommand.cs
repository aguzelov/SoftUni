using Employees.App.Core.Commands.Contracts;
using Employees.App.Models;
using Employees.Services.Contracts;
using System;

namespace Employees.App.Core.Commands
{
    public class AddEmployeeCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public AddEmployeeCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public void Execute(string[] data)
        {
            if (data.Length != 3)
            {
                throw new ArgumentException("Invalid command!");
            }

            string firstName = data[0];
            string lastName = data[1];

            decimal salary = decimal.Parse(data[2]);

            EmployeeDto employeeDto = new EmployeeDto
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.employeeService.AddEmployee<EmployeeDto>(employeeDto);
        }
    }
}