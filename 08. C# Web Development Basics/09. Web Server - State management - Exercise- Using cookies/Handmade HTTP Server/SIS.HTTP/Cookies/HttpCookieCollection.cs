using SIS.HTTP.Cookies.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SIS.HTTP.Cookies
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
        private Dictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            if (!this.ContainsCookie(cookie.Key))
            {
                this.cookies.Add(cookie.Key, null);
            }

            this.cookies[cookie.Key] = cookie;
        }

        public bool ContainsCookie(string key)
        {
            bool isContains = this.cookies.ContainsKey(key);

            return isContains;
        }

        public HttpCookie GetCookie(string key)
        {
            if (!this.ContainsCookie(key))
            {
                return null;
            }

            return this.cookies[key];
        }

        public bool HasCookies()
        {
            bool hasCookies = this.cookies.Any();

            return hasCookies;
        }

        public override string ToString()
        {
            return string.Join("; ", this.cookies.Values);
        }
    }
}