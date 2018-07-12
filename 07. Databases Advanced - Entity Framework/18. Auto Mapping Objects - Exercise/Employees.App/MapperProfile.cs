using AutoMapper;
using Employees.App.Models;
using Employees.Models;

namespace Employees.App
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, Employee>();

            CreateMap<ManagerDto, Employee>();

            CreateMap<EmployeeWithManagerDto, Employee>();
        }
    }
}