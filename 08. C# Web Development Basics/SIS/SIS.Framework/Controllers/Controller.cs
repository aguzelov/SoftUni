using SIS.Framework.ActionResult;
using SIS.Framework.ActionResult.Contracts;
using SIS.Framework.Models;
using SIS.Framework.Services.UserCookieServices;
using SIS.Framework.Utilities;
using SIS.Framework.Views;
using SIS.HTTP.Cookies;
using SIS.HTTP.Requests.Contracts;
using System.Runtime.CompilerServices;

namespace SIS.Framework.Controllers
{
    public abstract class Controller
    {
        private readonly IUserCookieService userCookieService;

        protected Controller()
        {
        }

        protected Controller(IUserCookieService userCookieService)
        {
            this.userCookieService = userCookieService;
            this.Model = new ViewModel();
        }

        public Model ModelState { get; } = new Model();

        protected ViewModel Model { get; }

        protected bool IsAuthenticatedUser => this.Username != null;
        protected string Username => this.userCookieService.GetUsername(this.Request.Cookies);

        public IHttpRequest Request { get; set; }

        private HttpCookie Cookie { get; set; }

        protected void SetUserCookie(string username)
        {
            this.Cookie = this.userCookieService.GetUserCookie(username);
        }

        protected void SetUserCookie(HttpCookie cookie)
        {
            this.Cookie = cookie;
        }

        private void SetMenu()
        {
            if (this.IsAuthenticatedUser)
            {
                this.Model["guestMenu"] = "d-none";
                this.Model["userMenu"] = "d-block";
            }
            else
            {
                this.Model["guestMenu"] = "d-block";
                this.Model["userMenu"] = "d-none";
            }
        }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            this.SetMenu();

            var controllerName = ControllerUtilities.GetControllerName(this);

            var fullyQualifiedName = ControllerUtilities.GetViewFullQualifiedName(controllerName, caller);

            var view = new View(fullyQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl) => new RedirectResult(redirectUrl);
    }
}