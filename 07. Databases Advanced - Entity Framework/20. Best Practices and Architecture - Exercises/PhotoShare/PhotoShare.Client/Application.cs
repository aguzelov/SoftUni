namespace PhotoShare.Client
{
    using Core;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PhotoShare.Services;
    using PhotoShare.Services.Contracts;
    using System;

    public class Application
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();

            IDatabaseService databaseService = serviceProvider.GetService<IDatabaseService>();
            ICommandDispatcher commandDispatcher = serviceProvider.GetService<ICommandDispatcher>();
            Engine engine = new Engine(databaseService, commandDispatcher);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<PhotoShareContext>(options => options.UseSqlServer(ServerConfig.ConnectionString));

            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<IDatabaseService, DatabaseService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITownService, TownService>();
            services.AddTransient<IAlbumServise, AlbumService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IAlbumRoleService, AlbumRoleService>();
            services.AddTransient<IAlbumTagService, AlbumTagSerivce>();
            services.AddTransient<IAlbumUserService, AlbumUserService>();
            services.AddTransient<IFriendshipService, FriendshipService>();
            services.AddTransient<IPictureService, PictureService>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}