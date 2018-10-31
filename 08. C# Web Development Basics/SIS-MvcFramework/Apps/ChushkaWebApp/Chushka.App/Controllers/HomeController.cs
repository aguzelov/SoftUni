using Chushka.App.ViewModels;
using SIS.HTTP.Responses;
using System.Linq;

namespace Chushka.App.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var products = this.Db.Products
                    .Where(p => p.IsDeleted == false)
                     .Select(p => new ProductIndexViewModel
                     {
                         Id = p.Id,
                         Name = p.Name,
                         Description = p.Description,
                         Price = p.Price
                     }).ToList();

                var view = new IndexViewModel
                {
                    Products = products
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