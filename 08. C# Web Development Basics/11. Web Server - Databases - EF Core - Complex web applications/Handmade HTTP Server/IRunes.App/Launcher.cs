using IRunes.App.Controllers;
using IRunes.Data;
using IRunes.Services.AlbumServices;
using IRunes.Services.PasswordServices;
using IRunes.Services.TrackServices;
using IRunes.Services.UserCookieServices;
using IRunes.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIS.HTTP.Enums;
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

            IRunesContext context = provider.GetService<IRunesContext>();

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

            services.AddDbContext<IRunesContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddSingleton<HomeController>();
            services.AddSingleton<UserController>();
            services.AddSingleton<AlbumController>();
            services.AddSingleton<TrackController>();
            services.AddSingleton<BadRequestController>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IUserCookieService, UserCookieService>();
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<ITrackService, TrackService>();

            IServiceProvider provider = services.BuildServiceProvider();

            return provider;
        }

        private static ServerRoutingTable ConfigureRounting(IServiceProvider provider)
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => provider.GetService<HomeController>().Index(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Home/Index"] = request => provider.GetService<HomeController>().Index(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Users/Register"] = request => provider.GetService<UserController>().Register(request);

            serverRoutingTable.Routes[HttpRequestMethod.Post]["/Users/Register"] = request => provider.GetService<UserController>().Register(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Users/Login"] = request => provider.GetService<UserController>().Login(request);

            serverRoutingTable.Routes[HttpRequestMethod.Post]["/Users/Login"] = request => provider.GetService<UserController>().Login(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["Users/Logout"] = request =>
            provider.GetService<UserController>().Logout(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Albums/Create"] = request =>
            provider.GetService<AlbumController>().Create(request);

            serverRoutingTable.Routes[HttpRequestMethod.Post]["/Albums/Create"] = request =>
            provider.GetService<AlbumController>().Create(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Albums/All"] = request =>
            provider.GetService<AlbumController>().All(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get][@"/Albums/Details\?([a-zA-Z]+=[0-9A-Za-z-]+(&)?)+"] = request =>
            provider.GetService<AlbumController>().Details(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get][@"/Tracks/Create\?([a-zA-Z]+=[0-9A-Za-z-]+(&)?)+"] = request =>
            provider.GetService<TrackController>().Create(request);

            serverRoutingTable.Routes[HttpRequestMethod.Post][@"/Tracks/Create\?([a-zA-Z]+=[0-9A-Za-z-]+(&)?)+"] = request =>
            provider.GetService<TrackController>().Create(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get][@"/Tracks/Details\?([a-zA-Z]+=[0-9A-Za-z-]+(&)?)+"] = request =>
            provider.GetService<TrackController>().Details(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["notfound"] = request =>
            provider.GetService<BadRequestController>().NotFound(request);

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