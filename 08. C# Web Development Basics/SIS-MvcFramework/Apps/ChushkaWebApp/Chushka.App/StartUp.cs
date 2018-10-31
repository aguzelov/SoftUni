using Chushka.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Services;

namespace Chushka.App
{
    public class StartUp : IMvcApplication
    {
        public MvcFrameworkSettings Configure()
        {
            return new MvcFrameworkSettings()
            {
                PortNumber = 8000
            };
        }

        public void ConfigureServices(IServiceCollection collection)
        {
            collection.AddService<IUserService, UserService>();
        }
    }
}