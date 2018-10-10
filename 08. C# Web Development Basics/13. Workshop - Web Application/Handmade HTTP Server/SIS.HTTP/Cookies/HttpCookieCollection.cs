using SIS.HTTP.Cookies.Contracts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SIS.HTTP.Cookies
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly Dictionary<string, HttpCookie> _cookies;

        public HttpCookieCollection()
        {
            this._cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            if (!ContainsCookie(cookie.Key))
            {
                this._cookies.Add(cookie.Key, null);
            }

            this._cookies[cookie.Key] = cookie;
        }

        public bool ContainsCookie(string key)
        {
            bool isContains = this._cookies.ContainsKey(key);

            return isContains;
        }

        public HttpCookie GetCookie(string key)
        {
            if (!ContainsCookie(key))
            {
                return null;
            }

            return this._cookies[key];
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            foreach (var cookie in _cookies)
            {
                yield return cookie.Value;
            }
        }

        public bool HasCookies()
        {
            bool hasCookies = this._cookies.Any();

            return hasCookies;
        }

        public override string ToString()
        {
            return string.Join("; ", this._cookies.Values);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}