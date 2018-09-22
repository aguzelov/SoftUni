using HTTPServer.ByTheCakeApp.Data;
using HTTPServer.ByTheCakeApp.Infrastructure;
using HTTPServer.ByTheCakeApp.Models;
using HTTPServer.Server.Enums;
using HTTPServer.Server.Http.Contracts;
using System;
using System.Linq;

namespace HTTPServer.ByTheCakeApp.Controllers
{
    public class CakesController : Controller
    {
        private readonly CakesData cakesData;

        public CakesController(IHttpRequest req)
            : base(req)
        {
            this.cakesData = new CakesData();
        }

        public IHttpResponse Add()
        {
            if (base.Request.Method == HttpRequestMethod.Get)
            {
                this.ViewData["name"] = "Please, enter data in both fields:";
                this.ViewData["price"] = "[name] and [price].";
                this.ViewData["showResult"] = "block";

                return FileViewResponse(@"cakes\add");
            }

            var formNameKey = "name";
            var formPriceKey = "price";

            if (!base.Request.FormData.ContainsKey(formNameKey) ||
                !base.Request.FormData.ContainsKey(formPriceKey))
            {
                this.ViewData["name"] = "Please, enter data in both fields:";
                this.ViewData["price"] = "[name] and [price].";
                this.ViewData["showResult"] = "block";

                return FileViewResponse(@"cakes\add");
            }
            else
            {
                var name = base.Request.FormData[formNameKey];
                var price = base.Request.FormData[formPriceKey];

                var cake = new Cake
                {
                    Name = name,
                    Price = decimal.Parse(price)
                };

                this.cakesData.Add(name, price);

                var priceToShow = decimal.Parse(price);

                this.ViewData["name"] = $"name: {name}";
                this.ViewData["price"] = $"price: {priceToShow:F2}";
                this.ViewData["showResult"] = "block";
            }

            return FileViewResponse(@"cakes\add");
        }

        public IHttpResponse Search()
        {
            const string searchTermKey = "searchTerm";

            var urlParameters = base.Request.UrlParameters;

            this.ViewData["results"] = string.Empty;
            this.ViewData["searchTerm"] = string.Empty;

            if (urlParameters.ContainsKey(searchTermKey))
            {
                var searchTerm = urlParameters[searchTermKey];

                this.ViewData["searchTerm"] = searchTerm;

                var savedCakesDivs = this.cakesData
                    .All()
                    .Where(c => c.Name.ToLower().Contains(searchTerm.ToLower()))
                    .Select(c => $@"<div>{c.Name} - ${c.Price:F2} <a href=""/shopping/add/{c.Id}?searchTerm={searchTerm}"">Order</a></div>");

                var results = "No cakes found";

                if (savedCakesDivs.Any())
                {
                    results = string.Join(Environment.NewLine, savedCakesDivs);
                }

                this.ViewData["results"] = results;
            }
            else
            {
                this.ViewData["results"] = "Please, enter search term";
            }

            this.ViewData["showCart"] = "none";

            var shoppingCart = base.Request.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (shoppingCart != null && shoppingCart.Orders.Any())
            {
                var totalProducts = shoppingCart.Orders.Count;
                var totalProductsText = totalProducts != 1 ? "products" : "product";

                this.ViewData["showCart"] = "block";
                this.ViewData["products"] = $"{totalProducts} {totalProductsText}";
            }

            return FileViewResponse(@"cakes\search");
        }
    }
}