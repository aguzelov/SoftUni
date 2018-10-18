using SIS.Framework.ActionResult.Contracts;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Services.UserCookieServices;

namespace IRunes.App.Controllers
{
    public class BadRequestController : BaseController
    {
        public BadRequestController(IUserCookieService userCookieService) : base(userCookieService)
        {
        }

        [HttpGet]
        public IActionResult NotFound()
        {
            return this.View("notfound");
        }
    }
}