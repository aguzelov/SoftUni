using SIS.Framework;
using SIS.Framework.Routers;
using SIS.WebServer;

namespace SIS.Demo
{
    public class Launcher
    {
        private static void Main(string[] args)
        {
            var server = new Server(8000, new ControllerRouter(), new ResourceRouter());

            MvcEngine.Run(server);
        }
    }
}