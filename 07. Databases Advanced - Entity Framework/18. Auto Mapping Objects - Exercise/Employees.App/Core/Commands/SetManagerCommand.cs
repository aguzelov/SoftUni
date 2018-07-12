using Employees.App.Core.Commands.Contracts;
using Employees.Services.Contracts;
using System;

namespace Employees.App.Core.Commands
{
    public class SetManagerCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public SetManagerCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public void Execute(string[] data)
        {
            if (data.Length != 2)
            {
                throw new ArgumentException("Invalid command!");
            }

            int employeeId = int.Parse(data[0]);
            int managerId = int.Parse(data[1]);

            this.employeeService.SetManager(employeeId, managerId);
        }
    }
}