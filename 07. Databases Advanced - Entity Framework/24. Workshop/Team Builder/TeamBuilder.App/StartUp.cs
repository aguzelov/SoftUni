using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using TeamBuilder.App.Core;
using TeamBuilder.App.Core.Contracts;
using TeamBuilder.Data;
using TeamBuilder.Services;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigServices();

            IDispatcher dispatcher = serviceProvider.GetService<IDispatcher>();
            Engine engine = new Engine(dispatcher);
            engine.Run();
        }

        private static IServiceProvider ConfigServices()
        {
            IServiceCollection services = new ServiceCollection();
            string path = GetConfigurationFilePath();

            var config = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<TeamBuilderContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(cfg => cfg.AddProfile<MapperProfile>());

            services.AddSingleton<IDispatcher, CommandDispatcher>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDbService, DbService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IInvitationService, InvitationService>();
            services.AddTransient<IUserTeamService, UserTeamService>();
            services.AddTransient<ITeamEventService, TeamEventService>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
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