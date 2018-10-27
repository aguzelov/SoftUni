using System;
using System.Collections.Generic;
using System.Text;
using IRunes.App.Controllers;
using IRunes.Data;
using IRunes.Services.AlbumServices;
using IRunes.Services.PasswordServices;
using IRunes.Services.TrackServices;
using IRunes.Services.UserServices;
using SIS.Framework.Api;
using SIS.Framework.Routers;
using SIS.Framework.Services.Contracts;
using SIS.Framework.Services.UserCookieServices;
using SIS.WebServer.Api.Contracts;

namespace IRunes.App
{
    public class StartUp : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            //dependencyContainer.RegisterDependency<IHomeService, HomeService>();

            dependencyContainer.RegisterDependency<IRunesContext, IRunesContext>();

            dependencyContainer.RegisterDependency<IHttpHandlingContext, HttpRouteHandlingContext>();
            dependencyContainer.RegisterDependency<IControllerHandler, ControllerRouter>();
            dependencyContainer.RegisterDependency<IResourceHandler, ResourceRouter>();

            dependencyContainer.RegisterDependency<HomeController, HomeController>();
            dependencyContainer.RegisterDependency<UsersController, UsersController>();
            dependencyContainer.RegisterDependency<AlbumsController, AlbumsController>();
            dependencyContainer.RegisterDependency<TracksController, TracksController>();
            dependencyContainer.RegisterDependency<BadRequestController, BadRequestController>();

            dependencyContainer.RegisterDependency<IUserService, UserService>();
            dependencyContainer.RegisterDependency<IHashService, HashService>();
            dependencyContainer.RegisterDependency<IUserCookieService, UserCookieService>();
            dependencyContainer.RegisterDependency<IAlbumService, AlbumService>();
            dependencyContainer.RegisterDependency<ITrackService, TrackService>();
        }
    }
}