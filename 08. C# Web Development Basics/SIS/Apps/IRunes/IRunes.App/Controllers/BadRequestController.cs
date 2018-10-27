using SIS.Framework.ActionsResults.Base;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Services.UserCookieServices;

namespace IRunes.App.Controllers
{
    public class BadRequestController : BaseController
    {
        public BadRequestController()
        {
        }

        [HttpGet]
        public IActionResult NotFound()
        {
            return this.View("notfound");
        }
    }
}