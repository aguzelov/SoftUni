using SIS.MvcFramework;

namespace Chushka.App
{
    public class Launcher
    {
        private static void Main(string[] args)
        {
            WebHost.Start(new StartUp());
        }
    }
}