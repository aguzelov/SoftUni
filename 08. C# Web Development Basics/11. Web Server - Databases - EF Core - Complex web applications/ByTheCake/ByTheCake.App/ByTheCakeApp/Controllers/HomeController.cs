using HTTPServer.ByTheCakeApp.Infrastructure;
using HTTPServer.Server.Http.Contracts;

namespace HTTPServer.ByTheCakeApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IHttpResponse Index()
        {
            return FileViewResponse(@"home\index");
        }

        public IHttpResponse About()
        {
            return FileViewResponse(@"home\about");
        }
    }
}