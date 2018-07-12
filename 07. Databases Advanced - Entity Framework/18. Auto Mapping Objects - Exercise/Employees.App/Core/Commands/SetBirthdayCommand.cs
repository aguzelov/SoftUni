using Employees.App.Core.Commands.Contracts;
using Employees.Services.Contracts;
using System;
using System.Globalization;

namespace Employees.App.Core.Commands
{
    public class SetBirthdayCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public SetBirthdayCommand(IEmployeeService employeeService)
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
            DateTime birthday = DateTime.ParseExact(data[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            this.employeeService.SetBirthday(employeeId, birthday);
        }
    }
}