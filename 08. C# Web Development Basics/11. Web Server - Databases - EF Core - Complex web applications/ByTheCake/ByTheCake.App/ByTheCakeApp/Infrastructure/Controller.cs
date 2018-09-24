using HTTPServer.ByTheCakeApp.Views;
using HTTPServer.Server.Enums;
using HTTPServer.Server.Http.Contracts;
using HTTPServer.Server.Http.Response;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HTTPServer.ByTheCakeApp.Infrastructure
{
    public abstract class Controller
    {
        public const string DefaultPath = @"..\..\..\ByTheCakeApp\Resources\{0}.html";

        public const string ContentPlaceholder = "{{{content}}}";
        public const string ButtonPlaceholder = "{{{value}}}";

        protected Controller()
        {
            this.ViewData = new Dictionary<string, string>
            {
                ["authDisplay"] = "block"
            };

            ////ButtonValue = Request.Session.HasSessions == true ? "Logout" : "Login";
        }

        private static string ButtonValue { get; set; }

        protected IDictionary<string, string> ViewData { get; private set; }

        protected IHttpResponse FileViewResponse(string fileName)
        {
            var result = ProcessFileHtml(fileName);

            if (this.ViewData.Any())
            {
                foreach (var value in this.ViewData)
                {
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        private static string ProcessFileHtml(string fileName)
        {
            var layoutHtml = File.ReadAllText(string.Format(DefaultPath, "layout"));

            var fileHtml = File.ReadAllText(string.Format(DefaultPath, fileName));

            var result = layoutHtml.Replace(ContentPlaceholder, fileHtml);
            result = result.Replace(ButtonPlaceholder, ButtonValue);

            return result;
        }
    }
}