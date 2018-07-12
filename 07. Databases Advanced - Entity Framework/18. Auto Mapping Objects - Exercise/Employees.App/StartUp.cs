using AutoMapper;
using Employees.App.Core;
using Employees.App.Core.Contracts;
using Employees.App.Core.IO;
using Employees.App.Core.IO.Contracts;
using Employees.Data;
using Employees.Services;
using Employees.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employees.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigServiceProvider();

            ICommandInterpreter commandInterpreter = serviceProvider.GetService<ICommandInterpreter>();

            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<EmployeesContext>(option => option.UseSqlServer(DbConfig.ConnectionString));

            services.AddAutoMapper(cfg => cfg.AddProfile<MapperProfile>());

            services.AddTransient<ICommandInterpreter, CommandInterpreter>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddSingleton<IOutputWriter, OutputWriter>();

            IServiceProvider provider = services.BuildServiceProvider();

            return provider;
        }
    }
}