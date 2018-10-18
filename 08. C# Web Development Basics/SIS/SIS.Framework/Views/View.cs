using SIS.Framework.ActionResult.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;

        private readonly string layoutName;

        private readonly IDictionary<string, object> viewData;

        public View(string fullyQualifiedTemplateName, IDictionary<string, object> viewData)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
            this.viewData = viewData;

            this.layoutName = "Views\\_Layout";
        }

        private string ReadFile(string fileName)
        {
            var file = fileName + ".html";

            if (!File.Exists(file))
            {
                throw new FileNotFoundException();
            }

            var htmlText = File.ReadAllText(file);
            return htmlText;
        }

        public string Render()
        {
            var layoutHtml = this.ReadFile(this.layoutName);
            var pageHtml = this.ReadFile(this.fullyQualifiedTemplateName);

            var content = layoutHtml.Replace("@RenderBody()", pageHtml);

            var renderedHtml = this.RenderHtml(content);

            return renderedHtml;
        }

        private string RenderHtml(string fullHtml)
        {
            var renderedHtml = fullHtml;

            if (this.viewData.Any())
            {
                foreach (var parameter in this.viewData)
                {
                    renderedHtml = renderedHtml
                        .Replace($"{{{{{{{parameter.Key}}}}}}}",
                        parameter.Value.ToString());
                }
            }

            return renderedHtml;
        }
    }
}