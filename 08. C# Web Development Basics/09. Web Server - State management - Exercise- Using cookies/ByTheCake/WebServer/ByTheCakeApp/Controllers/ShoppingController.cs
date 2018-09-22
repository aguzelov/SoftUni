using HTTPServer.ByTheCakeApp.Data;
using HTTPServer.ByTheCakeApp.Infrastructure;
using HTTPServer.ByTheCakeApp.Models;
using HTTPServer.Server.Http.Contracts;
using HTTPServer.Server.Http.Response;
using System.Linq;

namespace HTTPServer.ByTheCakeApp.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly CakesData cakesData;

        public ShoppingController(IHttpRequest req)
            : base(req)
        {
            this.cakesData = new CakesData();
        }

        public IHttpResponse AddToCart()
        {
            var id = int.Parse(base.Request.UrlParameters["id"]);

            var cake = this.cakesData.Find(id);

            if (cake == null)
            {
                return new NotFoundResponse();
            }

            var shoppingCart = base.Request.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            shoppingCart.Orders.Add(cake);

            var redirectUrl = "/search";

            const string searchTermKey = "searchTerm";

            if (base.Request.UrlParameters.ContainsKey(searchTermKey))
            {
                redirectUrl = $"{redirectUrl}?{searchTermKey}={base.Request.UrlParameters[searchTermKey]}";
            }

            return new RedirectResponse(redirectUrl);
        }

        public IHttpResponse ShowCart()
        {
            var shoppingCart = base.Request.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

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

        public IHttpResponse FinishOrder()
        {
            base.Request.Session.Get<ShoppingCart>(ShoppingCart.SessionKey).Orders.Clear();

            return FileViewResponse(@"shopping\finish-order");
        }
    }
}