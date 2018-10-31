using Chushka.App.Models;
using Chushka.App.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System.Linq;

namespace Chushka.App.Controllers
{
    public class OrdersController : BaseController
    {
        [Authorize]
        public IHttpResponse Order(int id)
        {
            var product = this.Db.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return BadRequestErrorWithView("Invalid product id!");
            }

            var user = this.Db.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (user == null)
            {
                return BadRequestErrorWithView("Invalid user!");
            }

            var order = new Order
            {
                Product = product,
                Client = user
            };

            this.Db.Orders.Add(order);
            this.Db.SaveChanges();

            return this.Redirect("/Orders/All");
        }

        [Authorize("Admin")]
        public IHttpResponse All()
        {
            var orders = this.Db.Orders
                .Where(o => o.Client.Username == this.User.Username)
                .Select(o => new OrderViewModel
                {
                    Id = o.Id,
                    Username = o.Client.Username,
                    ProductName = o.Product.Name,
                    OrderedOn = o.OrderedOn.ToString("HH:mm dd/MM/yyyy")
                })
                .ToList();

            var view = new AllOrdersViewModel
            {
                Orders = orders
            };

            return this.View(view);
        }
    }
}