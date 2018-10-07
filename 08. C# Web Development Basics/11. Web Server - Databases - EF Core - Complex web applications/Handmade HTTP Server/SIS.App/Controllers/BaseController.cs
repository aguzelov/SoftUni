using SIS.HTTP.Enums;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Results;
using System.Collections.Generic;
using System.IO;

namespace SIS.App.Controllers
{
    public abstract class BaseController
    {
        protected Dictionary<string, string> ViewData;

        protected BaseController()
        {
            this.ViewData = new Dictionary<string, string>()
            {
                {"display", "none" }
            };
        }

        protected IHttpResponse View(string viewFileName)
        {
            var content = File.ReadAllText("Views/" + viewFileName + ".html");

            content = this.AddViewData(content);

            return new HtmlResult(content, HttpResponseStatusCode.OK);
        }

        protected IHttpResponse Redirect(string location)
        {
            return new RedirectResult(location, HttpResponseStatusCode.Found);
        }

        private string AddViewData(string content)
        {
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