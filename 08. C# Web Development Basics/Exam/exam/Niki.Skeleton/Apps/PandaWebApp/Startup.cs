namespace PandaWebApp
{
    using PandaWebApp.Data;
    using PandaWebApp.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Logger;
    using SIS.MvcFramework.Services;

    public class Startup : IMvcApplication
    {
        public MvcFrameworkSettings Configure()
        {
            return new MvcFrameworkSettings { PortNumber = 80 };
        }

        public void ConfigureServices(IServiceCollection collection)
        {
            collection.AddService<ILogger, ConsoleLogger>();
            collection.AddService<IUserService, UserService>();
            collection.AddService<PandaContext, PandaContext>();
        }
    }
}