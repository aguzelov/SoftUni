using SIS.Framework.ActionsResults.Base;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Services.UserCookieServices;

namespace IRunes.App.Controllers
{
    public class HomeController : BaseController
    {
        private const string GuestPage = "Index-guest";
        private const string UserPage = "Index-user";

        public HomeController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (this.Identity() == null)
            {
                return this.View(GuestPage);
            }

            this.ViewModel["username"] = this.Identity().Username;

            return this.View(UserPage);
        }
    }
}