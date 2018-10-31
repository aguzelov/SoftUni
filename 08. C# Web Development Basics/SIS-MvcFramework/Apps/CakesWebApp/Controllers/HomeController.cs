using SIS.HTTP.Responses;

namespace CakesWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            return this.View();
        }
    }

    public class HelloUserViewModel
    {
        public string Username { get; set; }
    }
}