using SIS.Framework.ActionResult.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;

        private readonly IDictionary<string, object> viewData;

        public View(string fullyQualifiedTemplateName, IDictionary<string, object> viewData)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
            this.viewData = viewData;
        }

        private string ReadFile()
        {
            var fileName = this.fullyQualifiedTemplateName + ".html";

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }

            var htmlText = File.ReadAllText(fileName);
            return htmlText;
        }

        public string Render()
        {
            var fullHtml = this.ReadFile();
            var renderedHtml = this.RenderHtml(fullHtml);

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