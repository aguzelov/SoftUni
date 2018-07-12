using AutoMapper;
using AutoMapper.QueryableExtensions;
using Employees.Data;
using Employees.Models;
using Employees.Services.Contracts;
using System;
using System.Linq;

namespace Employees.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeesContext context;

        public EmployeeService(EmployeesContext context)
        {
            this.context = context;
        }

        public void AddEmployee<TModel>(TModel dto)
        {
            Employee employee = Mapper.Map<Employee>(dto);

            this.context.Employees.Add(employee);

            this.context.SaveChanges();
        }

        public IQueryable<TModel> All<TModel>()
        {
            var employees = this.context.Employees
                 .ProjectTo<TModel>();

            return employees;
        }

        public TModel GetEmploye<TModel>(int employeeId)
        {
            TModel employee = this.context.Employees
                 .Where(e => e.EmployeeId == employeeId)
                 .ProjectTo<TModel>()
                 .SingleOrDefault();

            if (employee == null)
            {
                throw new InvalidOperationException($"Employee with id {employeeId} not found!");
            }

            return employee;
        }

        public void SetAddress(int employeeId, string address)
        {
            Employee employee = this.GetEmploye<Employee>(employeeId);

            employee.Address = address;

            context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime birthday)
        {
            Employee employee = this.GetEmploye<Employee>(employeeId);

            employee.Birthday = birthday;

            context.SaveChanges();
        }

        public void SetManager(int employeeId, int managerId)
        {
            Employee employee = this.GetEmploye<Employee>(employeeId);
            Employee manager = this.GetEmploye<Employee>(managerId);

            employee.Manager = manager;

            context.SaveChanges();
        }
    }
}