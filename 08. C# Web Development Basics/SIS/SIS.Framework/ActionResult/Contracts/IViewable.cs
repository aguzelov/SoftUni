namespace SIS.Framework.ActionResult.Contracts
{
    public interface IViewable : IActionResult
    {
        IRenderable View { get; set; }
    }
}