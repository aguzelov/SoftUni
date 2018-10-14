using SIS.HTTP.Enums;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Results;
using System.Collections.Generic;
using System.IO;

namespace SIS.App.IRunes.App.Controllers
{
    public abstract class BaseController
    {
        protected Dictionary<string, string> ViewData;

        protected BaseController()
        {
            this.IsAuthenticatedUser = true;
            this.ViewData = new Dictionary<string, string>()
            {
                {"display", "none" }
            };
        }

        protected IHttpResponse View(string viewFileName)
        {
            var layoutContent = File.ReadAllText("Views/_Layout.html");
            var content = File.ReadAllText("Views/" + viewFileName + ".html");

            content = layoutContent.Replace("@RenderBody()", content);

            content = this.AddViewData(content);

            return new HtmlResult(content, HttpResponseStatusCode.OK);
        }

        protected IHttpResponse Redirect(string location)
        {
            return new RedirectResult(location, HttpResponseStatusCode.Found);
        }

        protected bool IsAuthenticatedUser { get; set; }

        private string AddViewData(string content)
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
    }
}