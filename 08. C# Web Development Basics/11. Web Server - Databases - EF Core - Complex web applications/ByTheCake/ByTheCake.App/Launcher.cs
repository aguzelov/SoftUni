using ByTheCake.Data;
using HTTPServer.Server;
using HTTPServer.Server.Routing;

namespace HTTPServer
{
    public class Launcher
    {
        private static void Main(string[] args)
        {
            var context = new ByTheCakeContext();

            Run(args, context);
        }

        private static void Run(string[] args, ByTheCakeContext context)
        {
            //TODO: Initialize application
            var byTheCakeApp = new ByTheCakeApp.ByTheCakeApplication(context);

            var appRouteConfig = new AppRouteConfig();
            //TODO: Configure App Route Configuration
            byTheCakeApp.Configure(appRouteConfig);

            var server = new WebServer(8080, appRouteConfig);

            server.Run();
        }
    }
}