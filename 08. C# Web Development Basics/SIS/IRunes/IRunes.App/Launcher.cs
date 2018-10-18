using IRunes.App.Controllers;
using IRunes.Data;
using IRunes.Services.AlbumServices;
using IRunes.Services.PasswordServices;
using IRunes.Services.TrackServices;
using IRunes.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using SIS.Framework;
using SIS.Framework.Routers;
using SIS.Framework.Services;
using SIS.Framework.Services.UserCookieServices;
using SIS.WebServer;
using SIS.WebServer.Api;

namespace IRunes.App
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            IDependencyContainer service = ConfigureService();

            IRunesContext context = service.CreateInstance<IRunesContext>();

            context.Database.Migrate();

            var controllerRouter = service.CreateInstance<IHandleable>();

            var server = new Server(8000, new ControllerRouter(service), new ResourceRouter());

            MvcEngine.Run(server);
        }

        private static IDependencyContainer ConfigureService()
        {
            IDependencyContainer services = new DependencyContainer();

            services.RegisterDependency<IRunesContext, IRunesContext>();

            services.RegisterDependency<IHandleable, ControllerRouter>();

            services.RegisterDependency<HomeController, HomeController>();
            services.RegisterDependency<UsersController, UsersController>();
            services.RegisterDependency<AlbumsController, AlbumsController>();
            services.RegisterDependency<TracksController, TracksController>();
            services.RegisterDependency<BadRequestController, BadRequestController>();

            services.RegisterDependency<IUserService, UserService>();
            services.RegisterDependency<IPasswordService, PasswordService>();
            services.RegisterDependency<IUserCookieService, UserCookieService>();
            services.RegisterDependency<IAlbumService, AlbumService>();
            services.RegisterDependency<ITrackService, TrackService>();

            return services;
        }
    }
}