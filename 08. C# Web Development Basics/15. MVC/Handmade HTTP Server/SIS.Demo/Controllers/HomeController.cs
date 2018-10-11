using SIS.Framework.ActionResult.Contracts;
using SIS.Framework.Controllers;

namespace SIS.Demo.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}