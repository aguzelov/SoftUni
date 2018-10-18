using SIS.Framework.Controllers;
using SIS.Framework.Services.UserCookieServices;

namespace IRunes.App.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController(IUserCookieService userCookieService) : base(userCookieService)
        {
        }
    }
}