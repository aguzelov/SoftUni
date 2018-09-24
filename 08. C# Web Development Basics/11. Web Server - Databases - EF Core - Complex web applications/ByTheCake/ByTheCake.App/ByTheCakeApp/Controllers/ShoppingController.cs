using ByTheCake.Data;
using ByTheCake.Models;
using HTTPServer.ByTheCakeApp.Infrastructure;
using HTTPServer.ByTheCakeApp.Models;
using HTTPServer.Server.Http;
using HTTPServer.Server.Http.Contracts;
using HTTPServer.Server.Http.Response;
using System;
using System.Linq;

namespace HTTPServer.ByTheCakeApp.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly ByTheCakeContext context;

        public ShoppingController(ByTheCakeContext context)
        {
            this.context = context;
        }

        public IHttpResponse AddToCart(IHttpRequest req)
        {
            var id = int.Parse(req.UrlParameters["id"]);

            var product = this.context.Products.Find(id);

            if (product == null)
            {
                return new NotFoundResponse();
            }

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            shoppingCart.Orders.Add(product);

            var redirectUrl = "/search";

            const string searchTermKey = "searchTerm";

            if (req.UrlParameters.ContainsKey(searchTermKey))
            {
                redirectUrl = $"{redirectUrl}?{searchTermKey}={req.UrlParameters[searchTermKey]}";
            }

            return new RedirectResponse(redirectUrl);
        }

        public IHttpResponse ShowCart(IHttpRequest req)
        {
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (!shoppingCart.Orders.Any())
            {
                this.ViewData["cartItems"] = "No items in your cart";
                this.ViewData["totalCost"] = "0.00";
            }
            else
            {
                var items = shoppingCart
                    .Orders
                    .Select(i => $"<div>{i.Name} - ${i.Price:F2}</div><br />");

                var totalPrice = shoppingCart
                    .Orders
                    .Sum(i => i.Price);

                this.ViewData["cartItems"] = string.Join(string.Empty, items);
                this.ViewData["totalCost"] = $"{totalPrice:F2}";
            }

            return FileViewResponse(@"shopping\cart");
        }

        public IHttpResponse FinishOrder(IHttpRequest req)
        {
            var products = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey).Orders;
            var user = req.Session.Get<User>(SessionStore.CurrentUserKey);

            var order = new Order()
            {
                User = user,
                DateOfCreation = DateTime.UtcNow
            };

            foreach (var product in products)
            {
                order.Products.Add(new ProductsOrders()
                {
                    Product = product
                });
            }

            this.context.Orders.Add(order);
            this.context.SaveChanges();

            req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey).Orders.Clear();

            return FileViewResponse(@"shopping\finish-order");
        }
    }
}