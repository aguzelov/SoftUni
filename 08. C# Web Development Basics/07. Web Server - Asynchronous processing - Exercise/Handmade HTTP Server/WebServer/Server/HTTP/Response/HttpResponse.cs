using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Common;
using WebServer.Server.Contracts;
using WebServer.Server.Enums;
using WebServer.Server.HTTP.Contracts;

namespace WebServer.Server.HTTP.Response
{
    public abstract class HttpResponse : IHttpResponse
    {
        private readonly IView view;

        protected HttpResponse(string redirectUrl)
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader("Location", redirectUrl);
        }

        protected HttpResponse(HttpStatusCode responseCode, IView view)
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.view = view;
            this.StatusCode = responseCode;
        }

        public void AddHeader(string key, string redirectUrl)
        {
            HttpHeader header = new HttpHeader(key, redirectUrl);
            this.HeaderCollection.Add(header);
        }

        public HttpStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection HeaderCollection { get; set; }

        private string StatusMessage => this.StatusCode.ToString();

        public string Response
        {
            get
            {
                StringBuilder response = new StringBuilder();

                var statusCodeNumber = (int)this.StatusCode;

                response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.StatusMessage}");

                response.AppendLine(this.HeaderCollection.ToString());
                response.AppendLine();

                if ((int)this.StatusCode < 300 || (int)this.StatusCode > 400)
                {
                    response.AppendLine(this.view.View());
                }

                return response.ToString();
            }
        }
    }
}