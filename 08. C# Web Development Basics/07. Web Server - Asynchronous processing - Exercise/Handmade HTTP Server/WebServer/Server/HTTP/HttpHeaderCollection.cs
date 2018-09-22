using System;
using System.Collections.Generic;
using WebServer.Server.Common;
using WebServer.Server.HTTP.Contracts;

namespace WebServer.Server.HTTP
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));

            var headerKey = header.Key;

            if (!this.ContainsKey(headerKey))
            {
                this.headers[headerKey] = null;
            }

            this.headers[headerKey] = header;
        }

        public bool ContainsKey(string key)
        {
            CoreValidator.ThrowIfNull(key, nameof(key));

            var isContains = this.headers.ContainsKey(key);
            return isContains;
        }

        public HttpHeader GetHeader(string key)
        {
            if (!this.ContainsKey(key))
            {
                throw new InvalidOperationException($"Th given key {key} is not present in the headers collection.");
            }

            return this.headers[key];
        }

        public override string ToString()
        {
            return string.Join("\n", this.headers);
        }
    }
}