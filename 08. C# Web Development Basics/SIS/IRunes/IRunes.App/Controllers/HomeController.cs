using IRunes.Services.UserCookieServices;
using SIS.Framework.ActionResult.Contracts;
using SIS.Framework.Attributes.Methods;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;

namespace IRunes.App.Controllers
{
    public class HomeController : BaseController
    {
        private const string GuestPage = "Index-guest";
        private const string UserPage = "Index-user";
        private readonly IUserCookieService userCookieService;

        public HomeController(IUserCookieService userCookieService)
        {
            this.userCookieService = userCookieService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var username = this.userCookieService.GetUsername(this.Request.Cookies);

            if (username == null)
            {
                return this.View(GuestPage);
            }

            this.Model["username"] = username;

            return this.View(UserPage);
        }
    }
}