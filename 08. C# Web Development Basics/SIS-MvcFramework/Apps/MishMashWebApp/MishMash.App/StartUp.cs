using MishMash.Data;
using MishMash.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Services;

namespace MishMash.App
{
    public class StartUp : IMvcApplication
    {
        public MvcFrameworkSettings Configure()
        {
            return new MvcFrameworkSettings();
        }

        public void ConfigureServices(IServiceCollection collection)
        {
            collection.AddService<MishMashContext, MishMashContext>();
            collection.AddService<IHashService, HashService>();
            collection.AddService<IUserCookieService, UserCookieService>();
            collection.AddService<IUserService, UserService>();
            collection.AddService<IChannelService, ChannelService>();
        }
    }
}