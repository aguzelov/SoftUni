using SIS.Framework.ActionResult;
using SIS.Framework.ActionResult.Contracts;
using SIS.Framework.Models;
using SIS.Framework.Services.UserCookieServices;
using SIS.Framework.Utilities;
using SIS.Framework.Views;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses;
using SIS.HTTP.Responses.Contracts;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIS.Framework.Controllers
{
    public abstract class Controller
    {
        private readonly IUserCookieService UserCookieService;

        public Controller()
        {
            this.Response = new HttpResponse();

            this.UserCookieService = new UserCookieService();

            this.Model = new ViewModel();

            this.ViewData = new Dictionary<string, string>()
            {
                {"display", "none" }
            };
        }

        protected ViewModel Model { get; }

        protected Dictionary<string, string> ViewData;

        protected bool IsAuthenticatedUser => this.Username != null;

        public IHttpRequest Request { get; set; }

        protected IHttpResponse Response { get; set; }

        protected string Username => this.UserCookieService.GetUsername(this.Request.Cookies);

        protected IHttpResponse Text(string content)
        {
            this.Response.Headers.Add(new HttpHeader(HttpHeader.ContentType, "text/plain"));
            this.Response.Content = Encoding.UTF8.GetBytes(content);
            this.Response.StatusCode = HttpResponseStatusCode.OK;

            return this.Response;
        }

        public void SetUserCookie(string username)
        {
            var cookie = this.UserCookieService.GetUserCookie(username);

            this.Response.Cookies.Add(cookie);
        }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            if (IsAuthenticatedUser)
            {
                this.Model.Data["guestMenu"] = "d-none";
                this.Model.Data["userMenu"] = "d-block";
            }
            else
            {
                this.Model.Data["guestMenu"] = "d-block";
                this.Model.Data["userMenu"] = "d-none";
            }

            var controllerName = ControllerUtilities.GetControllerName(this);

            var fullyQualifiedName = ControllerUtilities.GetViewFullQualifiedName(controllerName, caller);

            var view = new View(fullyQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl) => new RedirectResult(redirectUrl);
    }
}