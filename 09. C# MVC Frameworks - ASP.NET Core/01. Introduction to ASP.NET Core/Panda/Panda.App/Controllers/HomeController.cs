using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Panda.App.Infrastructure;
using Panda.App.Models;
using Panda.Services.Contracts;

namespace Panda.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPackageService packageService;
        private readonly ILogger logger;

        public HomeController(IPackageService packageService, ILogger<HomeController> logger)
        {
            this.packageService = packageService;
            this.logger = logger;
        }

        public IActionResult Index()
        {

            if (this.User.Identity.IsAuthenticated)
            {
                var username = this.User.Identity.Name;

                var model = this.packageService.GetUserPackagesByStatus<PackageViewModel>(username);

                return this.View("LoggedInIndex", model);
            }
            else
            {
                return this.View();
            }
        }
    }
}