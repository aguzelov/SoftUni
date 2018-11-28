using Eventures.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Eventures.Web.Filters
{
    public class SetTempDataModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            base.OnActionExecuted(filterContext);
            if (controller != null)
            {
                controller.TempData.Put<ModelStateDictionary>("ModelState", controller.ViewData.ModelState);
            }
        }
    }
}