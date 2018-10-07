using SIS.App.Models;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.Models;
using SIS.Services.CakeServices;
using SIS.Services.ShoppingServices;
using SIS.Services.UserCookieServices;
using SIS.Services.UserServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.App.Controllers
{
    public class ShoppingController : BaseController
    {
        private readonly IShoppingService shoppingService;
        private readonly ICakeService cakeService;
        private readonly IUserService UserService;
        private readonly IUserCookieService UserCookieService;

        public ShoppingController(IShoppingService shoppingService, ICakeService cakeService, IUserService userService, IUserCookieService userCookieService)
        {
            this.shoppingService = shoppingService;
            this.cakeService = cakeService;
            UserService = userService;
            UserCookieService = userCookieService;
        }

        public IHttpResponse AddToCart(IHttpRequest request)
        {
            var id = int.Parse(request.UrlParameter);

            var cake = this.cakeService.Get(id);

            if (cake == null)
            {
                return this.Redirect("/search");
            }

            if (!request.Session.ContainsParameter(ShoppingCart.SessionKey))
            {
                request.Session.AddParameter(ShoppingCart.SessionKey, new ShoppingCart());
            }

            var shoppingCart = (ShoppingCart)request.Session.GetParameter(ShoppingCart.SessionKey);

            shoppingCart.Products.Add(cake);

            return this.Redirect("/search");
        }

        public IHttpResponse Order(IHttpRequest request)
        {
            if (request.RequestMethod == HTTP.Enums.HttpRequestMethod.Get)
            {
                var currentCart = (ShoppingCart)request.Session.GetParameter(ShoppingCart.SessionKey);

                var sb = new StringBuilder();
                foreach (var product in currentCart.Products)
                {
                    sb.Append(
                    $"<tr>" +
                        $"<td><a href=\"/cakeDetails/{product.Id}\">{product.Id}</a></td>" +
                        $"<td>{product.Name}</td>" +
                        $"<td>${product.Price}</td>" +
                    $"</tr>"
                    );
                }

                sb.Append($"<tr>" +
                            $"<td colspan=2>Total</td>" +
                            $"<td>${currentCart.Products.Sum(p => p.Price)}</td>" +
                            $"</tr>");

                this.ViewData["order"] = sb.ToString();
                return this.View("order");
            }

            var username = this.UserCookieService.GetUsername(request.Cookies);

            var user = this.UserService.Get(username);

            if (user == null)
            {
                return this.Redirect("/login");
            }

            var cart = (ShoppingCart)request.Session.GetParameter(ShoppingCart.SessionKey);

            var products = new List<OrderProducts>();

            foreach (var product in cart.Products)
            {
                products.Add(new OrderProducts() { Product = product });
            }

            var order = new Order()
            {
                User = user,
                Products = products
            };

            this.shoppingService.Add(order);

            request.Session.AddParameter(ShoppingCart.SessionKey, new ShoppingCart());

            return this.Redirect("/");
        }

        public IHttpResponse Orders(IHttpRequest request)
        {
            var username = this.UserCookieService.GetUsername(request.Cookies);

            var user = this.UserService.Get(username);

            if (user == null)
            {
                return this.Redirect("/login");
            }

            var orders = this.shoppingService.GetOrderByUserId(user.Id);

            var sb = new StringBuilder();

            foreach (var order in orders)
            {
                sb.Append($"<tr>" +
                           $"<td><a href=\"/orderDetails/{order.Id}\">{order.Id}</a></td>" +
                            $"<td>{order.DateOfCreating.ToString("dd-MM-yyyy")}</td>" +
                             $"<td>{order.Products.Sum(p => p.Product.Price)}</td>" +
                             $"</tr>");
            }

            this.ViewData["orders"] = sb.ToString();

            return this.View("orders");
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            var id = int.Parse(request.UrlParameter);

            var order = this.shoppingService.GetOrderById(id);

            if (order == null)
            {
                return this.Redirect("/orders");
            }

            var sb = new StringBuilder();

            foreach (var product in order.Products)
            {
                sb.Append($"<tr>" +
                           $"<td><a href=\"/cakeDetails/{product.Product.Id}\">{product.Product.Name}</a></td>" +
                             $"<td>{product.Product.Price}</td>" +
                             $"</tr>");
            }

            this.ViewData["orders"] = sb.ToString();
            this.ViewData["createdMessage"] = $"Created on: {order.DateOfCreating.ToString("dd-MM-yyyy")}";

            return this.View("orderDetails");
        }
    }
}