using SIS.HTTP.Responses.Contracts;

namespace SIS.App.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            return this.View("index");
        }
    }
}