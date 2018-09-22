using HTTPServer.ByTheCakeApp.Infrastructure;
using HTTPServer.ByTheCakeApp.Models;
using HTTPServer.Server.Enums;
using HTTPServer.Server.Http;
using HTTPServer.Server.Http.Contracts;
using HTTPServer.Server.Http.Response;

namespace HTTPServer.ByTheCakeApp.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(IHttpRequest req)
            : base(req)
        {
        }

        public IHttpResponse Login()
        {
            if (base.Request.Method == HttpRequestMethod.Get)
            {
                this.ViewData["showError"] = "block";
                this.ViewData["authDisplay"] = "none";
                this.ViewData["error"] = "Please, enter data in both fields!";

                return FileViewResponse(@"account\login");
            }

            const string formNameKey = "name";
            const string formPasswordKey = "password";

            if (!base.Request.FormData.ContainsKey(formNameKey) ||
                !base.Request.FormData.ContainsKey(formPasswordKey))
            {
                this.ViewData["showError"] = "block";
                this.ViewData["authDisplay"] = "none";
                this.ViewData["error"] = "You have empty fields";

                return FileViewResponse(@"account\login");
            }

            var name = base.Request.FormData[formNameKey];
            var password = base.Request.FormData[formPasswordKey];

            base.Request.Session.Add(SessionStore.CurrentUserKey, name);
            base.Request.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());

            //return this.FileViewResponse(@"home\index");
            return new RedirectResponse("/");
        }

        public IHttpResponse Logout()
        {
            base.Request.Session.Clear();

            return new RedirectResponse("/login");
        }
    }
}