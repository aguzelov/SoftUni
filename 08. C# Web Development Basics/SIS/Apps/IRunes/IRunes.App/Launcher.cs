using IRunes.Data;
using Microsoft.EntityFrameworkCore;
using SIS.Framework;

namespace IRunes.App
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            IRunesContext context = new IRunesContext();

            context.Database.Migrate();

            WebHost.Start(new StartUp());
        }
    }
}