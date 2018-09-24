using ByTheCake.App.ByTheCakeApp.Utilities;
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
    public class AccountController : Controller
    {
        private readonly ByTheCakeContext context;

        public AccountController(ByTheCakeContext context)
        {
            this.context = context;
        }

        public IHttpResponse Login()
        {
            return ShowLoginViewWithErrorMessage();
        }

        public IHttpResponse Login(IHttpRequest req)
        {
            const string formUsernameKey = "username";
            const string formPasswordKey = "password";

            if (!req.FormData.ContainsKey(formUsernameKey) ||
                !req.FormData.ContainsKey(formPasswordKey))
            {
                return ShowLoginViewWithErrorMessage();
            }
            var username = req.FormData[formUsernameKey];
            var password = req.FormData[formPasswordKey];

            if (!UserHelper.ValidateUserInput(username, password))
            {
                return ShowLoginViewWithErrorMessage();
            }

            var userInputHashPassword = UserHelper.ComputePassword(password);

            var user = this.context.Users
                .Where(u => u.Username == username && u.Password == userInputHashPassword)
                .FirstOrDefault();

            if (user == null || user.Password != userInputHashPassword)
            {
                return ShowLoginViewWithErrorMessage();
            }

            req.Session.Add(SessionStore.CurrentUserKey, user);
            req.Session.Add(SessionStore.CurrentUserId, user.Id);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());

            //return this.FileViewResponse(@"home\index");
            return new RedirectResponse("/");
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();

            return new RedirectResponse("/login");
        }

        public IHttpResponse Register()
        {
            return ShowRegisterViewWithErrorMessage();
        }

        public IHttpResponse Register(IHttpRequest req)
        {
            const string formNameKey = "name";
            const string formUsernameKey = "username";
            const string formPasswordKey = "password";
            const string formConfirmPasswordKey = "confirm-password";

            if (!req.FormData.ContainsKey(formNameKey) ||
                !req.FormData.ContainsKey(formUsernameKey) ||
                !req.FormData.ContainsKey(formPasswordKey) ||
                !req.FormData.ContainsKey(formConfirmPasswordKey))
            {
                return ShowRegisterViewWithErrorMessage();
            }

            var name = req.FormData[formNameKey];
            var username = req.FormData[formUsernameKey];
            var password = req.FormData[formPasswordKey];
            var confirmPassword = req.FormData[formConfirmPasswordKey];

            if (!UserHelper.ValidateUserInput(name, username, password, confirmPassword))
            {
                return ShowRegisterViewWithErrorMessage();
            }

            var hashPassword = UserHelper.ComputePassword(password);

            var user = new User
            {
                Name = name,
                Username = username,
                Password = hashPassword,
                DateOfRegistration = DateTime.UtcNow
            };

            using (context)
            {
                this.context.Users.Add(user);
                context.SaveChanges();
            }

            req.Session.Add(SessionStore.CurrentUserKey, user);
            req.Session.Add(SessionStore.CurrentUserId, user.Id);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());

            return new RedirectResponse("/");
        }

        public IHttpResponse Profile(IHttpRequest req)
        {
            var user = this.context.Users.Find(req.Session.Get(SessionStore.CurrentUserId));
            var ordersCount = this.context.Orders
                .Where(o => o.UserId == user.Id)
                .Count();

            this.ViewData["name"] = user.Name;
            this.ViewData["registrationDate"] = user.DateOfRegistration.ToShortDateString();
            this.ViewData["orders"] = ordersCount.ToString();
            this.ViewData["showError"] = "block";
            this.ViewData["authDisplay"] = "display";
            this.ViewData["error"] = "Please, enter corect data in all fields!";

            return FileViewResponse(@"account\profile");
        }

        public IHttpResponse Orders(IHttpRequest req)
        {
            var userId = (int)req.Session.Get(SessionStore.CurrentUserId);
            var orders = this.context.Orders
                .Where(o => o.UserId == userId)
                .Select(o => new
                {
                    Id = o.Id,
                    Date = o.DateOfCreation,
                    Sum = o.Products.Sum(po => po.Product.Price)
                })
                .ToArray();

            var items = orders
                      .Select(o => $@"<tr><td><a href=""/orderDetails/{o.Id}"">{o.Id}</a></td><td>{o.Date.ToString("dd - MM - yyy")}</td><td>${o.Sum:F2}</td></tr>");

            this.ViewData["orders"] = string.Join(string.Empty, items);
            this.ViewData["showError"] = "block";
            this.ViewData["authDisplay"] = "display";
            this.ViewData["error"] = "Please, enter corect data in all fields!";

            return FileViewResponse(@"account\orders");
        }

        public IHttpResponse OrderDetails(IHttpRequest req)
        {
            var id = int.Parse(req.UrlParameters["id"]);

            var order = this.context.Orders.Find(id);

            if (order == null)
            {
                return new NotFoundResponse();
            }

            var products = this.context.ProductsOrders
                .Where(po => po.OrderId == order.Id)
                .Select(p => new
                {
                    Id = p.Product.Id,
                    Name = p.Product.Name,
                    Price = p.Product.Price
                })
                .ToArray();

            var items = products
                .Select(o => $@"<tr><td><a href=""/cakeDetails/{o.Id}"">{o.Name}</a></td><td>${o.Price:F2}</td></tr>");

            this.ViewData["orders"] = string.Join(string.Empty, items);
            this.ViewData["date"] = order.DateOfCreation.ToString("dd-MM-yyyy");
            this.ViewData["showError"] = "block";
            this.ViewData["authDisplay"] = "display";
            this.ViewData["error"] = "Please, enter corect data in all fields!";

            return FileViewResponse(@"account\orderDetails");
        }

        private IHttpResponse ShowRegisterViewWithErrorMessage()
        {
            this.ViewData["showError"] = "block";
            this.ViewData["authDisplay"] = "none";
            this.ViewData["error"] = "Please, enter corect data in all fields!";

            return FileViewResponse(@"account\register");
        }

        private IHttpResponse ShowLoginViewWithErrorMessage()
        {
            this.ViewData["showError"] = "block";
            this.ViewData["authDisplay"] = "none";
            this.ViewData["error"] = "Please, enter data in both fields!";

            return FileViewResponse(@"account\login");
        }
    }
}