using SIS.HTTP.Common;
using SIS.HTTP.Cookies;
using SIS.HTTP.Cookies.Contracts;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;
using SIS.HTTP.Headers.Contracts;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Sessions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public string UrlParameter { get; set; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public IHttpSession Session { get; set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private bool IsValidRequestLine(string[] requestLine)
        {
            if (requestLine.Length == 3 &&
                requestLine[2] == GlobalConstants.HttpOneProtocolFragment)
            {
                return true;
            }

            return false;
        }

        private bool IsValidRequesttQueryString(string queryString, string[] queryParameters)
        {
            if (!string.IsNullOrEmpty(queryString) &&
                queryParameters.Length > 0)
            {
                return true;
            }
            return false;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            var requestMethodString = requestLine[0].Capitalize();

            var isParsed = Enum.TryParse(typeof(HttpRequestMethod), requestMethodString, out object requestMethod);

            if (isParsed)
            {
                this.RequestMethod = (HttpRequestMethod)requestMethod;
            }
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            var requestUrl = requestLine[1];

            this.Url = requestUrl;
        }

        private void ParseRequestPath()
        {
            var path = this.Url.Split("?").First();
            this.Path = path;
        }

        private void ParseHeaders(string[] requestContent)
        {
            int index = 0;
            while (true)
            {
                if (string.IsNullOrEmpty(requestContent[index]))
                {
                    break;
                }

                var headerTockens = requestContent[index].Split(": ");
                var headerKey = headerTockens[0];
                var headerValue = headerTockens[1];

                var header = new HttpHeader(headerKey, headerValue);

                this.Headers.Add(header);

                index++;
            }

            if (!this.Headers.ContainsHeader(GlobalConstants.HostHeaderKey))
            {
                throw new BadRequestException();
            }
        }

        private void ParseQueryParameters()
        {
            var queryString = this.Url.Split("?", StringSplitOptions.RemoveEmptyEntries);
            if (queryString.Length <= 1)
            {
                return;
            }

            var queryParameters = queryString.Last().Split("&");

            if (IsValidRequesttQueryString(queryString.Last(), queryParameters))
            {
                throw new BadRequestException();
            }

            foreach (var parameter in queryParameters)
            {
                var parameterTockens = parameter.Split("=");

                var parameterKey = parameterTockens[0];
                var parameterValue = parameterTockens[1];

                this.QueryData.Add(parameterKey, parameterValue);
            }
        }

        private void ParseFormDataParameters(string formData)
        {
            if (string.IsNullOrEmpty(formData))
            {
                return;
            }

            var parameters = formData.Split("&");

            foreach (var parameter in parameters)
            {
                var formatedParameter = parameter.Replace("+", " ");

                var parameterTockens = formatedParameter.Split("=");

                var parameterKey = parameterTockens[0];
                var parameterValue = parameterTockens[1];

                this.FormData.Add(parameterKey, parameterValue);
            }
        }

        private void ParseRequestParameters(string formData)
        {
            ParseQueryParameters();
            ParseFormDataParameters(formData);
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(Environment.NewLine);

            string[] requestLine = splitRequestContent[0].Trim()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (!IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            ParseRequestMethod(requestLine);
            ParseRequestUrl(requestLine);
            ParseRequestPath();

            ParseHeaders(splitRequestContent.Skip(1).ToArray());
            ParseCookies();

            ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }

        private void ParseCookies()
        {
            var searchingKey = "Cookie";

            if (this.Headers.ContainsHeader(searchingKey))
            {
                var header = this.Headers.GetHeader(searchingKey);

                var values = header.Values;

                var cookiesParameters = values.Split("; ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var cookieParameters in cookiesParameters)
                {
                    var cookieTokens = cookieParameters.Split("=", 2);

                    var key = cookieTokens[0];
                    var value = cookieTokens[1];

                    var cookie = new HttpCookie(key, value, false);

                    this.Cookies.Add(cookie);
                }
            }
        }
    }
}