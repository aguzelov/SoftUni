using SIS.Framework.ActionResult;
using SIS.Framework.ActionResult.Contracts;
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
            this.ViewData = new Dictionary<string, string>()
            {
                {"display", "none" }
            };
        }

        protected Dictionary<string, string> ViewData;

        protected bool IsAuthenticatedUser => this.Username != null;

        public IHttpRequest Request { get; set; }

        protected IHttpResponse Response { get; set; }

        protected string Username => this.UserCookieService.GetUsername(this.Request.Cookies);

        //protected IHttpResponse View(string viewFileName)
        //{
        //    var layoutContent = File.ReadAllText("Views/_Layout.html");
        //    var content = File.ReadAllText("Views/" + viewFileName + ".html");

        //    content = layoutContent.Replace("@RenderBody()", content);

        //    content = this.AddToViewData(content);
        //    this.Response.Headers.Add(new HttpHeader(HttpHeader.ContentType, "text/html"));
        //    this.Response.Content = Encoding.UTF8.GetBytes(content);
        //    this.Response.StatusCode = HttpResponseStatusCode.OK;

        //    return this.Response;
        //}

        protected IHttpResponse Redirect(string location)
        {
            this.Response.Headers.Add(new HttpHeader("Location", location));
            this.Response.StatusCode = HttpResponseStatusCode.Found;
            return this.Response;
        }

        protected IHttpResponse Text(string content)
        {
            this.Response.Headers.Add(new HttpHeader(HttpHeader.ContentType, "text/plain"));
            this.Response.Content = Encoding.UTF8.GetBytes(content);
            this.Response.StatusCode = HttpResponseStatusCode.OK;

            return this.Response;
        }

        public virtual IHttpResponse NotFound()
        {
            return null;
            // return this.View("notfound");
        }

        public void SetUserCookie(string username)
        {
            var cookie = this.UserCookieService.GetUserCookie(username);

            this.Response.Cookies.Add(cookie);
        }

        private string AddToViewData(string content)
        {
            if (IsAuthenticatedUser)
            {
                this.ViewData["guestMenu"] = "d-none";
                this.ViewData["userMenu"] = "d-block";
            }
            else
            {
                this.ViewData["guestMenu"] = "d-block";
                this.ViewData["userMenu"] = "d-none";
            }

            if (this.ViewData.Count != 0)
            {
                foreach (var data in this.ViewData)
                {
                    content = content.Replace($"{{{{{{{data.Key}}}}}}}", data.Value);
                }
            }

            return content;
        }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            var controllerName = ControllerUtilities.GetControllerName(this);

            var fullyQualifiedName = ControllerUtilities.GetViewFullQualifiedName(controllerName, caller);

            var view = new View(fullyQualifiedName);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl) => new RedirectResult(redirectUrl);
    }
}