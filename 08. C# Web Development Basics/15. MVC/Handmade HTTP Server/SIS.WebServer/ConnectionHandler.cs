using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.HTTP.Sessions;
using SIS.WebServer.Api;
using SIS.WebServer.Results;
using SIS.WebServer.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIS.WebServer
{
    public class ConnectionHandler
    {
        private readonly Socket _client;

        private readonly ServerRoutingTable _serverRoutingTable;
        private readonly IHandleable handler;

        public ConnectionHandler(Socket client)
        {
            this._client = client;
        }

        public ConnectionHandler(Socket client, ServerRoutingTable serverRoutingTable)
            : this(client)
        {
            this._serverRoutingTable = serverRoutingTable;
        }

        public ConnectionHandler(Socket client, IHandleable handler)
            : this(client)
        {
            this.handler = handler;
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfBytesRead = await this._client.ReceiveAsync(data.Array, SocketFlags.None);

                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);
                result.Append(bytesAsString);

                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }

        private IHttpResponse HandleRequest(IHttpRequest httpRequest)
        {
            var requestMethod = httpRequest.RequestMethod;

            var requestPath = httpRequest.Url;

            var registeredRoutes = this._serverRoutingTable.Routes[requestMethod];

            foreach (var registeredRoute in registeredRoutes)
            {
                var route = registeredRoute.Key;
                var routePattern = this.ParseRoute(registeredRoute.Key, new List<string>());

                var routingContext = registeredRoute.Value;

                var routeRegex = new Regex(routePattern);
                var match = routeRegex.Match(requestPath);

                if (!match.Success)
                {
                    continue;
                }

                var parameterValue = match.Groups[1].Value;
                httpRequest.UrlParameter = parameterValue;

                return this._serverRoutingTable.Routes[httpRequest.RequestMethod][route].Invoke(httpRequest);
            }

            IHttpResponse resource = ReturnIfResource(httpRequest.Path);
            if (resource != null)
            {
                return resource;
            }
            return this._serverRoutingTable.Routes[HttpRequestMethod.Get]["notfound"].Invoke(httpRequest);
        }

        private IHttpResponse ReturnIfResource(string path)
        {
            var fullPath = Environment.CurrentDirectory + path;

            if (File.Exists(fullPath))
            {
                var extension = path.Split(".", StringSplitOptions.RemoveEmptyEntries).Last();

                var contentString = File.ReadAllText(fullPath);
                var contentBytes = Encoding.UTF8.GetBytes(contentString);

                return new InlineResourceRasult(contentBytes, HttpResponseStatusCode.OK, extension);
            }

            return null;
        }

        private async Task PrepareResponse(IHttpResponse httpResponse)
        {
            byte[] byteSegments = httpResponse.GetBytes();

            await this._client.SendAsync(byteSegments, SocketFlags.None);
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = await ReadRequest();

            if (httpRequest != null)
            {
                string sessionId = SetRequestSession(httpRequest);

                IHttpResponse httpResponse = null;
                if (this.handler != null)
                {
                    httpResponse = this.handler.Handle(httpRequest);
                }
                else
                {
                    httpResponse = HandleRequest(httpRequest);
                }

                SetResponseSession(httpResponse, sessionId);

                await PrepareResponse(httpResponse);
            }

            this._client.Shutdown(SocketShutdown.Both);
        }

        private string SetRequestSession(IHttpRequest httpRequest)
        {
            string sessionId;

            if (httpRequest.Cookies.ContainsCookie(HttpSessionStorage.SessionCookieKey))
            {
                var cookie = httpRequest.Cookies.GetCookie(HttpSessionStorage.SessionCookieKey);
                sessionId = cookie.Value;
            }
            else
            {
                sessionId = Guid.NewGuid().ToString();
            }

            httpRequest.Session = HttpSessionStorage.GetSession(sessionId);

            return sessionId;
        }

        private void SetResponseSession(IHttpResponse httpResponse, string sessionId)
        {
            if (sessionId != null)
            {
                httpResponse
                    .AddCookie(new HttpCookie(HttpSessionStorage.SessionCookieKey,
                                            $"{sessionId};HttpOnly"));
            }
        }

        private string ParseRoute(string route, List<string> parameters)
        {
            if (route == "/")
            {
                return "^/$";
            }

            var result = new StringBuilder();

            result.Append("^/");

            var tokens = route.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            this.ParseTokens(tokens, parameters, result);

            return result.ToString();
        }

        private void ParseTokens(string[] tokens, List<string> parameters, StringBuilder result)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                var end = i == tokens.Length - 1 ? "$" : "/";
                var currentToken = tokens[i];

                if (!currentToken.StartsWith('{') && !currentToken.EndsWith('}'))
                {
                    result.Append($"{currentToken}{end}");
                    continue;
                }

                var parameterRegex = new Regex("<\\w+>");
                var parameterMatch = parameterRegex.Match(currentToken);

                if (!parameterMatch.Success)
                {
                    throw new InvalidOperationException($"Route parameter in '{currentToken}' is not valid.");
                }

                var match = parameterMatch.Value;
                var parameter = match.Substring(1, match.Length - 2);

                parameters.Add(parameter);

                var currentTokenWithoutCurlyBrackets = currentToken.Substring(1, currentToken.Length - 2);

                result.Append($"{currentTokenWithoutCurlyBrackets}{end}");
            }
        }
    }
}