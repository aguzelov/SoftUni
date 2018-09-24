namespace HTTPServer.Server.Handlers
{
    using Common;
    using Contracts;
    using Http.Contracts;
    using Http.Response;
    using HTTPServer.Server.Http;
    using Routing.Contracts;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig routeConfig)
        {
            CoreValidator.ThrowIfNull(routeConfig, nameof(routeConfig));

            this.serverRouteConfig = routeConfig;
        }

        public IHttpResponse Handle(IHttpContext context)
        {
            // Check if user is authenticated
            var loginPath = "/login";
            var registerPath = "/register";
            var allowedPaths = new[] { loginPath, registerPath };

            if (!allowedPaths.Contains(context.Request.Path) &&
                    (context.Request.Session == null ||
                    !context.Request.Session.Contains(SessionStore.CurrentUserKey)))
            {
                return new RedirectResponse(loginPath);
            }

            var requestMethod = context.Request.Method;
            var requestPath = context.Request.Path;
            var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];

            foreach (var registeredRoute in registeredRoutes)
            {
                var routePattern = registeredRoute.Key;
                var routingContext = registeredRoute.Value;

                var routeRegex = new Regex(routePattern);
                var match = routeRegex.Match(requestPath);

                if (!match.Success)
                {
                    continue;
                }

                var parameters = routingContext.Parameters;

                foreach (var parameter in parameters)
                {
                    var parameterValue = match.Groups[parameter].Value;
                    context.Request.AddUrlParameter(parameter, parameterValue);
                }

                return routingContext.Handler.Handle(context);
            }

            return new NotFoundResponse();
        }
    }
}