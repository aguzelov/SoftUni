using SIS.MvcFramework;
using SIS.MvcFramework.Services;
using Torshia.App.Services;
using Torshia.App.Services.Contracts;
using Torshia.Data;

namespace Torshia.App
{
    public class StartUp : IMvcApplication
    {
        public MvcFrameworkSettings Configure()
        {
            return new MvcFrameworkSettings();
        }

        public void ConfigureServices(IServiceCollection collection)
        {
            collection.AddService<TorshiaCotnext, TorshiaCotnext>();
            collection.AddService<IHashService, HashService>();
            collection.AddService<IUserService, UserService>();
            collection.AddService<ITaskService, TaskService>();
            collection.AddService<IReportService, ReportService>();
        }
    }
}