using HTTPServer.Server;
using HTTPServer.Server.Routing;

namespace HTTPServer
{
    internal class Launcher
    {
        private static void Main(string[] args)
        {
            Run(args);
        }

        private static void Run(string[] args)
        {
            //TODO: Initialize application
            var byTheCakeApp = new ByTheCakeApp.ByTheCakeApplication();

            var appRouteConfig = new AppRouteConfig();
            //TODO: Configure App Route Configuration
            byTheCakeApp.Configure(appRouteConfig);

            var server = new WebServer(8080, appRouteConfig);

            server.Run();
        }
    }
}