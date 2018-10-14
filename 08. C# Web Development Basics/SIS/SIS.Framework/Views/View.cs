using SIS.Framework.ActionResult.Contracts;
using System.IO;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;

        public View(string fullyQualifiedTemplateName)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
        }

        private string ReadFile(string fullyQualifiedTemplateName)
        {
            var fileName = fullyQualifiedTemplateName + ".html";

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }

            var htmlText = File.ReadAllText(fileName);
            return htmlText;
        }

        public string Render()
        {
            var fullHtml = this.ReadFile(this.fullyQualifiedTemplateName);

            return fullHtml;
        }
    }
}