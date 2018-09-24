using ByTheCake.Data;
using ByTheCake.Models;
using HTTPServer.ByTheCakeApp.Infrastructure;
using HTTPServer.ByTheCakeApp.Models;
using HTTPServer.Server.Http.Contracts;
using System;
using System.Linq;

namespace HTTPServer.ByTheCakeApp.Controllers
{
    public class CakesController : Controller
    {
        private readonly ByTheCakeContext context;

        public CakesController(ByTheCakeContext context)
        {
            this.context = context;
        }

        public IHttpResponse Add()
        {
            this.ViewData["name"] = "Please, enter data in both fields:";
            this.ViewData["price"] = "[name] and [price].";
            this.ViewData["showResult"] = "block";

            return FileViewResponse(@"cakes\add");
        }

        public IHttpResponse Add(IHttpRequest req)
        {
            var formNameKey = "name";
            var formPriceKey = "price";
            var formPictureURLKey = "pictureURL";

            if (!req.FormData.ContainsKey(formNameKey) ||
                !req.FormData.ContainsKey(formPriceKey) ||
                !req.FormData.ContainsKey(formPictureURLKey))
            {
                this.ViewData["name"] = "Please, enter data in all fields:";
                this.ViewData["price"] = "[name], [price] and [picture URL].";
                this.ViewData["showResult"] = "block";

                return FileViewResponse(@"cakes\add");
            }
            else
            {
                var name = req.FormData[formNameKey];
                var price = req.FormData[formPriceKey];
                var pictureURL = req.FormData[formPictureURLKey];

                var product = new Product
                {
                    Name = name,
                    Price = decimal.Parse(price),
                    ImageURL = pictureURL
                };

                this.context.Products.Add(product);
                this.context.SaveChanges();

                this.ViewData["name"] = $"name: {product.Name}";
                this.ViewData["price"] = $"price: {product.Price:F2}";
                this.ViewData["showResult"] = "block";
            }

            return FileViewResponse(@"cakes\add");
        }

        public IHttpResponse Search(IHttpRequest req)
        {
            const string searchTermKey = "searchTerm";

            var urlParameters = req.UrlParameters;

            this.ViewData["results"] = string.Empty;
            this.ViewData["searchTerm"] = string.Empty;

            if (urlParameters.ContainsKey(searchTermKey))
            {
                var searchedProductName = urlParameters[searchTermKey];

                this.ViewData["searchTerm"] = searchedProductName;

                var productsDivs = this.context
                    .Products
                    .Where(c => c.Name.ToLower().Contains(searchedProductName.ToLower()))
                    .Select(c => $@"<div><a href=""/cakeDetails/{c.Id}"">{c.Name}</a> - ${c.Price:F2} <button onclick=""location.href ='/shopping/add/{c.Id}?searchTerm={searchedProductName}'"">Order</button></div>");

                var results = "Cake Not Found";

                if (productsDivs.Any())
                {
                    results = string.Join(Environment.NewLine, productsDivs);
                }

                this.ViewData["results"] = results;
            }
            else
            {
                this.ViewData["results"] = "Please, enter search term";
            }

            this.ViewData["showCart"] = "none";

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (shoppingCart != null && shoppingCart.Orders.Any())
            {
                var totalProducts = shoppingCart.Orders.Count;
                var totalProductsText = totalProducts != 1 ? "products" : "product";

                this.ViewData["showCart"] = "block";
                this.ViewData["products"] = $"{totalProducts} {totalProductsText}";
            }

            return FileViewResponse(@"cakes\search");
        }

        public IHttpResponse Details(IHttpRequest req)
        {
            var id = int.Parse(req.UrlParameters["id"]);

            var product = this.context.Products.Find(id);

            if (product == null)
            {
                this.ViewData["searchTerm"] = string.Empty;
                this.ViewData["showCart"] = "none";
                this.ViewData["results"] = "Please, enter search term";
                return FileViewResponse(@"cakes\search");
            }

            this.ViewData["name"] = product.Name;
            this.ViewData["price"] = product.Price.ToString("F2");
            this.ViewData["imgURL"] = product.ImageURL;
            this.ViewData["showResult"] = "block";

            return FileViewResponse($@"cakes\cakeDetails");
        }
    }
}