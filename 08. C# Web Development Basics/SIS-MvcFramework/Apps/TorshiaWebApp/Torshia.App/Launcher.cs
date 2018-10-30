using Microsoft.EntityFrameworkCore;
using SIS.MvcFramework;
using Torshia.Data;

namespace Torshia.App
{
    public class Launcher
    {
        private static void Main(string[] args)
        {
            var context = new TorshiaCotnext();
            context.Database.Migrate();

            WebHost.Start(new StartUp());
        }
    }
}