using Chushka.App.Data;
using SIS.MvcFramework;

namespace Chushka.App.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new ChushkaContext();
        }

        public ChushkaContext Db { get; set; }
    }
}