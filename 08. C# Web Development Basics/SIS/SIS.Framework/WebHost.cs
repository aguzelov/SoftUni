using System;
using System.Collections.Generic;
using System.Text;
using SIS.Framework.Api.Contracts;
using SIS.Framework.Routers;
using SIS.Framework.Services;
using SIS.Framework.Services.Contracts;
using SIS.WebServer;
using SIS.WebServer.Api.Contracts;

namespace SIS.Framework
{
    public static class WebHost
    {
        private const int HostingPort = 8000;

        public static void Start(IMvcApplication application)
        {
            IDependencyContainer container = new DependencyContainer();
            application.ConfigureServices(container);

            IControllerHandler controllerRouter = new ControllerRouter(container);
            IResourceHandler resourceRouter = new ResourceRouter();

            IHttpHandlingContext handlingContextcontext = new HttpRouteHandlingContext(controllerRouter, resourceRouter);

            application.Configure();

            Server server = new Server(HostingPort, handlingContextcontext);
            server.Run();
        }
    }
}