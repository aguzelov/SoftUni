using Eventures.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Eventures.Web.Filters
{
    public class RestoreModelStateFromTempDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            base.OnActionExecuting(filterContext);

            if (controller.TempData.ContainsKey("ModelState"))
            {
                controller.ViewData.ModelState.Merge(
                controller.TempData.Get<ModelStateDictionary>("ModelState"));
            }
        }
    }
}