using SIS.HTTP.Headers.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SIS.HTTP.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> _headers;

        public HttpHeaderCollection()
        {
            this._headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            if (!ContainsHeader(header.Key))
            {
                this._headers[header.Key] = null;
            }

            this._headers[header.Key] = header;
        }

        public bool ContainsHeader(string key)
        {
            return this._headers.ContainsKey(key);
        }

        public IEnumerator<HttpHeader> GetEnumerator()
        {
            foreach (var header in this._headers)
            {
                yield return header.Value;
            }
        }

        public HttpHeader GetHeader(string key)
        {
            return !ContainsHeader(key) ? null : this._headers[key];
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this._headers.Values.ToString());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}