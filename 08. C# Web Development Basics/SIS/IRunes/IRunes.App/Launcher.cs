using System;
using System.IO;
using System.Linq;
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
using SIS.Framework;
using SIS.Framework.Routers;
using SIS.WebServer;
using SIS.WebServer.Api;

namespace IRunes.App
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            IServiceProvider provider = ConfigureService();

            IRunesContext context = provider.GetService<IRunesContext>();

            context.Database.Migrate();

            var controllerRouter = provider.GetService<IHandleable>();

            var server = new Server(8000, new ControllerRouter(provider), new ResourceRouter());

            MvcEngine.Run(server);
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

            services.AddTransient<IHandleable, ControllerRouter>();

            services.AddSingleton<HomeController>();
            services.AddSingleton<UserController>();
            services.AddSingleton<AlbumsController>();
            services.AddSingleton<TracksController>();
            services.AddSingleton<BadRequestController>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IUserCookieService, UserCookieService>();
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<ITrackService, TrackService>();

            IServiceProvider provider = services.BuildServiceProvider();

            return provider;
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