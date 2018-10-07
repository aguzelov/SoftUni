using SIS.App.Models;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.Services.CakeServices;
using System.Linq;
using System.Net;

namespace SIS.App.Controllers
{
    public class CakeController : BaseController
    {
        private readonly ICakeService cakeService;

        public CakeController(ICakeService cakeService)
        {
            this.cakeService = cakeService;
        }

        public IHttpResponse Add(IHttpRequest request)
        {
            if (request.RequestMethod == HTTP.Enums.HttpRequestMethod.Get)
            {
                return this.View("add");
            }

            var name = request.FormData["name"].ToString().Trim();
            var priceStr = request.FormData["price"].ToString().Trim();
            var url = request.FormData["url"].ToString().Trim();

            if (!IsValidCakeData(name, priceStr, url, out decimal price))
            {
                return this.View("add");
            }

            this.cakeService.Add(name, price, url);

            this.ViewData["display"] = "block";
            this.ViewData["message"] = $"{name} is added with {price} price";

            return this.View("add");
        }

        public IHttpResponse Search(IHttpRequest request)
        {
            var cakes = this.cakeService.GetAll();

            if (cakes.Count == 0)
            {
                this.ViewData["listDisplay"] = "block";
                this.ViewData["cakeMessage"] = "Cake Not Found";

                return this.View("search");
            }

            var cakesText = cakes
                .Select(
                c => $"<form action=\"/addToCart/{c.Id}\" method=\"get\">" +
                $"<a href=\"/cakeDetails/{c.Id}\">{c.Name}</a> ${c.Price}" +
                $" <input type=\"submit\" value=\"Order\" />" +
                $"</form>"
                )
                .ToArray();

            if (request.Session.ContainsParameter(ShoppingCart.SessionKey))
            {
                var cart = (ShoppingCart)request.Session.GetParameter(ShoppingCart.SessionKey);

                this.ViewData["display"] = "block";
                this.ViewData["message"] = $"<p>You have {cart.Products.Count()} products in shopping cart!</p>" +
                    $"<form action=\"/order\" method=\"get\">" +
                    $"<input type=\"submit\" value=\"Show Shopping Cart\" />" +
                    $"</form>";
            }

            this.ViewData["listDisplay"] = "block";
            this.ViewData["cakeMessage"] = string.Join("</br>", cakesText);

            return this.View("search");
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            var id = int.Parse(request.UrlParameter);

            var cake = this.cakeService.Get(id);

            if (cake == null)
            {
                return this.Redirect("/search");
            }

            this.ViewData["name"] = cake.Name;

            var url = WebUtility.UrlDecode(cake.ImageURL);
            this.ViewData["price"] = cake.Price.ToString();
            this.ViewData["url"] = url;

            return this.View("cakeDetails");
        }

        private bool IsValidCakeData(string name, string priceStr, string url, out decimal price)
        {
            bool isParsed = decimal.TryParse(priceStr, out price);

            return string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(url) ||
                !isParsed
                ? false
                : true;
        }
    }
}