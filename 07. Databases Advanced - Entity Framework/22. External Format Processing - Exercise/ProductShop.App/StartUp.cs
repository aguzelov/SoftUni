using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductShop.Data;
using ProductShop.Services;
using ProductShop.Services.Contracts;
using System;
using System.IO;

namespace ProductShop.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigServices();

            Engine engine = new Engine(serviceProvider);

            engine.Run();
        }

        private static IServiceProvider ConfigServices()
        {
            IServiceCollection services = new ServiceCollection();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<ProductShopContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(cfg => cfg.AddProfile<MapperProfile>());

            services.AddTransient<IDbService, DbService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryProductService, CategoryProductService>();

            IServiceProvider provider = services.BuildServiceProvider();

            return provider;
        }
    }
}