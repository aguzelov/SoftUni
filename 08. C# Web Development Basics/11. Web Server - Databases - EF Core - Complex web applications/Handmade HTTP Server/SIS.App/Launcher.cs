using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIS.App.Controllers;
using SIS.Data;
using SIS.HTTP.Enums;
using SIS.Services.CakeServices;
using SIS.Services.PasswordServices;
using SIS.Services.ShoppingServices;
using SIS.Services.UserCookieServices;
using SIS.Services.UserServices;
using SIS.WebServer;
using SIS.WebServer.Routing;
using System;
using System.IO;
using System.Linq;

namespace SIS.App
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            IServiceProvider provider = ConfigureService();

            ByTheCakeContext context = provider.GetService<ByTheCakeContext>();

            context.Database.Migrate();

            ServerRoutingTable serverRoutingTable = ConfigureRounting(provider);

            Server server = new Server(8000, serverRoutingTable);

            server.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            IServiceCollection services = new ServiceCollection();

            string path = GetConfigurationFilePath();

            var config = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<ByTheCakeContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddSingleton<HomeController>();
            services.AddSingleton<AccountController>();
            services.AddSingleton<CakeController>();
            services.AddSingleton<ShoppingController>();

            //services.AddControllersAsServices(typeof(Launcher).Assembly.GetExportedTypes()
            //.Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
            //.Where(t => typeof(BaseController).IsAssignableFrom(t)
            //|| t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IUserCookieService, UserCookieService>();
            services.AddTransient<ICakeService, CakeService>();
            services.AddTransient<IShoppingService, ShoppingService>();

            IServiceProvider provider = services.BuildServiceProvider();

            return provider;
        }

        private static ServerRoutingTable ConfigureRounting(IServiceProvider provider)
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => provider.GetService<HomeController>().Index();

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/register"] = request => provider.GetService<AccountController>().Register(request);

            serverRoutingTable.Routes[HttpRequestMethod.Post]["/register"] = request => provider.GetService<AccountController>().Register(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/login"] = request => provider.GetService<AccountController>().Login(request);

            serverRoutingTable.Routes[HttpRequestMethod.Post]["/login"] = request => provider.GetService<AccountController>().Login(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/profile"] = request => provider.GetService<AccountController>().Profile(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/add"] = request =>
            provider.GetService<CakeController>().Add(request);

            serverRoutingTable.Routes[HttpRequestMethod.Post]["/add"] = request =>
            provider.GetService<CakeController>().Add(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/search"] = request =>
            provider.GetService<CakeController>().Search(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/cakeDetails/(?<id>[0-9]+)"] = request =>
            provider.GetService<CakeController>().Details(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/addToCart/(?<id>[0-9]+)"] = request =>
            provider.GetService<ShoppingController>().AddToCart(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/order"] = request =>
            provider.GetService<ShoppingController>().Order(request);

            serverRoutingTable.Routes[HttpRequestMethod.Post]["/order"] = request =>
            provider.GetService<ShoppingController>().Order(request);

            //get /orders
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/orders"] = request =>
            provider.GetService<ShoppingController>().Orders(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/orderDetails/(?<id>[0-9]+)"] = request =>
            provider.GetService<ShoppingController>().Details(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["notfound"] = request =>
            new BadRequestController().NotFound(request);

            return serverRoutingTable;
        }

        private static string GetConfigurationFilePath()
        {
            string[] pathTokens = Directory
                .GetCurrentDirectory()
                .Split("\\");
            pathTokens = pathTokens.Take(pathTokens.Length - 4).ToArray();

            string path = string.Join("\\", pathTokens);

            return path;
        }
    }
}