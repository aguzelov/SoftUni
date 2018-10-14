using SIS.Framework.ActionResult.Contracts;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Controllers;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Api;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SIS.Framework.Routers
{
    public class ControllerRouter : IHandleable
    {
        private Controller GetController(string controllerName, IHttpRequest request)
        {
            if (controllerName != null)
            {
                string controllerTypeName = string.Format(
                    "{0}.{1}.{2}, {0}",
                    MvcContext.Get.AssemblyName,
                    MvcContext.Get.ControllersFolder,
                    controllerName);

                var controllerType = Type.GetType(controllerTypeName);
                var controller = (Controller)Activator.CreateInstance(controllerType);

                if (controller != null)
                {
                    controller.Request = request;
                }

                return controller;
            }

            return null;
        }

        private MethodInfo GetMethod(string requestMethod, Controller controller, string actionName)
        {
            MethodInfo method = null;

            foreach (var methodInfo in GetSuitableMethods(controller, actionName))
            {
                var attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(attr => attr is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>();

                if (!attributes.Any() && requestMethod.ToUpper() == "GET")
                {
                    return methodInfo;
                }

                foreach (var attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            var methods = controller
                            .GetType()
                            .GetMethods()
                            .Where(methodInfo => methodInfo.Name.ToLower() == actionName.ToLower());

            return methods;
        }

        private IHttpResponse PrepareResponse(Controller controller, MethodInfo action)
        {
            IActionResult actionResult = (IActionResult)action.Invoke(controller, null);
            string invocationResult = actionResult.Invoke();

            if (actionResult is IViewable)
            {
                return new HtmlResult(invocationResult, HttpResponseStatusCode.OK);
            }
            else if (actionResult is IRedirectable)
            {
                return new RedirectResult(invocationResult, HttpResponseStatusCode.MovedPermanently);
            }
            else
            {
                throw new InvalidOperationException("The view result is not supported.");
            }
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            var path = request.Path;

            if (path == "/" || path == "/favicon.ico")
            {
                path = "Home/Index";
            }

            var pathTockens = path.Split("/", StringSplitOptions.RemoveEmptyEntries);

            var controllerName = pathTockens[pathTockens.Length - 2] + MvcContext.Get.ControllersSuffix;
            var actionName = pathTockens[pathTockens.Length - 1];
            var requestMethod = request.RequestMethod.ToString();

            var controller = this.GetController(controllerName, request);

            MethodInfo action = this.GetMethod(requestMethod, controller, actionName);
            if (action == null)
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            return this.PrepareResponse(controller, action);
        }
    }
}