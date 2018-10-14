using SIS.App.IRunes.Services.UserCookieServices;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;

namespace SIS.App.IRunes.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserCookieService userCookieService;

        public HomeController(IUserCookieService userCookieService)
        {
            this.userCookieService = userCookieService;
        }

        public IHttpResponse Index(IHttpRequest request)
        {
            var username = this.userCookieService.GetUsername(request.Cookies);

            if (username == null)
            {
                this.IsAuthenticatedUser = false;
                return this.View("Home/Index-guest");
            }

            this.ViewData["username"] = username;

            this.IsAuthenticatedUser = true;
            return this.View("Home/Index-user");
        }
    }
}