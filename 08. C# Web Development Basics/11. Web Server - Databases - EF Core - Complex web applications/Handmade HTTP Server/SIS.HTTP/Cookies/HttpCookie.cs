using System;

namespace SIS.HTTP.Cookies
{
    public class HttpCookie
    {
        public const string AuthenticeKey = ".auth-cakes";

        private const int HttpCookieDefaultExpirationDays = 3;

        public HttpCookie(string key, string value, int expires = HttpCookieDefaultExpirationDays)
        {
            this.Key = key;
            this.Value = value;
            this.Expires = DateTime.UtcNow.AddDays(expires);
        }

        public HttpCookie(string key, string value, bool isNew, int expires = HttpCookieDefaultExpirationDays)
            : this(key, value, expires)
        {
            this.IsNew = isNew;
        }

        public string Key { get; set; }

        public string Value { get; set; }

        public DateTime Expires { get; set; }

        public bool IsNew { get; set; }

        public override string ToString()
        {
            return $"{this.Key}={this.Value}; Expires={this.Expires.ToString("R")}; HttpOnly; Path=/";
        }
    }
}