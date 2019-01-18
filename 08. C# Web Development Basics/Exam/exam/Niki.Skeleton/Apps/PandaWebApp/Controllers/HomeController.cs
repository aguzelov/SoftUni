namespace PandaWebApp.Controllers
{
    using PandaWebApp.Models;
    using PandaWebApp.ViewModels;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var products = this.Db.Packages
                    .Where(p => p.Recipient.Username == this.User.Username)
                     .Select(p => new PackageViewModel
                     {
                         Id = p.Id,
                         Name = p.Description,
                         Status = p.Status.ToString()
                     }).ToList();

                var view = new PackagesViewModel
                {
                    Shipped = products.Where(p => p.Status == "Shipped").ToList(),
                    Pending = products.Where(p => p.Status == "Pending").ToList(),
                    Delivered = products.Where(p => p.Status == "Delivered").ToList(),
                };

                return this.View("Home/LoggedInIndex", view);
            }
            else
            {
                return this.View();
            }
        }
    }
}