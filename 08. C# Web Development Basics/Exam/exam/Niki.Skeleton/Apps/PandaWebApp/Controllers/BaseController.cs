namespace PandaWebApp.Controllers
{
    using PandaWebApp.Data;
    using SIS.MvcFramework;

    public abstract class BaseController : Controller
    {
        public BaseController()
        {
            this.Db = new PandaContext();
        }

        public PandaContext Db { get; set; }
    }
}