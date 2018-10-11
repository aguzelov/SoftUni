using SIS.Framework.ActionResult.Contracts;

namespace SIS.Framework.ActionResult
{
    public class ViewResult : IViewable
    {
        public ViewResult(IRenderable view)
        {
            this.View = view;
        }

        public IRenderable View { get; set; }

        public string Invoke() => this.View.Render();
    }
}