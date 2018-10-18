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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using SIS.Framework.Services;

namespace SIS.Framework.Routers
{
    public class ControllerRouter : IHandleable
    {
        private const string UnsupportedActionMessage = "The view result is not supported.";

        private readonly IDependencyContainer Provider;

        public ControllerRouter(IDependencyContainer provider)
        {
            this.Provider = provider;
        }

        public ControllerRouter()
        {
            
        }

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

                var constructorInfo = controllerType.GetConstructors().FirstOrDefault();

                var parameters = constructorInfo.GetParameters()
                    .Select(p => this.Provider.CreateInstance(p.ParameterType))
                    .ToArray();

                var controller = (Controller)Activator.CreateInstance(controllerType, parameters);

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

        private IHttpResponse PrepareResponse(IActionResult actionResult)
        {
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
                throw new InvalidOperationException(UnsupportedActionMessage);
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

            object[] actionParametes = this.MapActionParameters(controller, action, request);

            IActionResult actionResult = this.InvokeAction(controller, action, actionParametes);

            return this.PrepareResponse(actionResult);
        }

        private IActionResult InvokeAction(Controller controller, MethodInfo action, object[] actionParametes)
        {
            return (IActionResult)action.Invoke(controller, actionParametes);
        }

        private object[] MapActionParameters(Controller controller, MethodInfo action, IHttpRequest request)
        {
            ParameterInfo[] actionParametersInfo = action.GetParameters();
            object[] mappedActionParameters = new object[actionParametersInfo.Length];

            for (int index = 0; index < actionParametersInfo.Length; index++)
            {
                ParameterInfo currentParameterInfo = actionParametersInfo[index];
                if (currentParameterInfo.ParameterType.IsPrimitive ||
                    currentParameterInfo.ParameterType == typeof(string))
                {
                    mappedActionParameters[index] = ProcessPrimitiveParameter(currentParameterInfo, request);
                }
                else
                {
                    object bindingModel = ProcessBindingModelParameter(currentParameterInfo, request);
                    controller.ModelState.IsValid = this.IsValid(bindingModel);
                    mappedActionParameters[index] = bindingModel;
                }
            }

            return mappedActionParameters;
        }

        private bool? IsValid(object bindingModel)
        {
            Type bindingModelType = bindingModel.GetType();

            var properties = bindingModelType.GetProperties();

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttributes(typeof(ValidationAttribute), true).Cast<ValidationAttribute>().FirstOrDefault();

                var value = property.GetValue(bindingModel);

                var isValid = attribute.IsValid(value);

                if (isValid == false) return false;
            }

            return true;
        }

        private object ProcessBindingModelParameter(ParameterInfo param, IHttpRequest request)
        {
            Type bindingModelType = param.ParameterType;

            var bindingModelInstance = Activator.CreateInstance(bindingModelType);
            var bindingModelProperties = bindingModelType.GetProperties();

            foreach (var property in bindingModelProperties)
            {
                try
                {
                    object value = this.GetParameterFromRequestData(request, property.Name);
                    property.SetValue(bindingModelInstance, Convert.ChangeType(value, property.PropertyType));
                }
                catch
                {
                    Console.WriteLine();
                }
            }

            return Convert.ChangeType(bindingModelInstance, bindingModelType);
        }

        private object ProcessPrimitiveParameter(ParameterInfo param, IHttpRequest request)
        {
            object value = this.GetParameterFromRequestData(request, param.Name);
            return Convert.ChangeType(value, param.ParameterType);
        }

        private object GetParameterFromRequestData(IHttpRequest request, string paramName)
        {
            if (request.QueryData.ContainsKey(paramName)) return request.QueryData[paramName];
            if (request.FormData.ContainsKey(paramName)) return request.FormData[paramName];
            return null;
        }
    }
}