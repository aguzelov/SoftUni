using System;
using System.Linq;

namespace Employees.Services.Contracts
{
    public interface IEmployeeService
    {
        void AddEmployee<TModel>(TModel dto);

        void SetAddress(int employeeId, string address);

        void SetBirthday(int employeeId, DateTime birthday);

        void SetManager(int employeeId, int managerId);

        TModel GetEmploye<TModel>(int employeeId);

        IQueryable<TModel> All<TModel>();
    }
}