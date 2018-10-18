using SIS.Framework.ActionResult.Contracts;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Services.UserCookieServices;

namespace IRunes.App.Controllers
{
    public class HomeController : BaseController
    {
        private const string GuestPage = "Index-guest";
        private const string UserPage = "Index-user";

        public HomeController(IUserCookieService userCookieService)
        : base(userCookieService)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (this.IsAuthenticatedUser)
            {
                return this.View(GuestPage);
            }

            this.Model["username"] = this.Username;

            return this.View(UserPage);
        }
    }
}