using System.Collections.Generic;

namespace SIS.HTTP.Headers.Contracts
{
    public interface IHttpHeaderCollection : IEnumerable<HttpHeader>
    {
        void Add(HttpHeader header);

        bool ContainsHeader(string key);

        HttpHeader GetHeader(string key);
    }
}