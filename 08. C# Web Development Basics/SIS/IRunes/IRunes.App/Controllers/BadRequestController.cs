using SIS.Framework.ActionResult.Contracts;
using SIS.Framework.Attributes.Methods;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;

namespace IRunes.App.Controllers
{
    public class BadRequestController : BaseController
    {
        [HttpGet]
        public IActionResult NotFound()
        {
            return this.View("notfound");
        }
    }
}