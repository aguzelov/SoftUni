namespace SIS.HTTP.Headers
{
    public class HttpHeader
    {
        public const string ContentType = "Content-Type";
        public const string ContentLength = "Content-Length";
        public const string ContentDisposition = "Content-Disposition";

        public HttpHeader(string key, string value)
        {
            this.Key = key;
            this.Values = value;
        }

        public string Key { get; set; }

        public string Values { get; set; }

        public override string ToString()
        {
            return $"{this.Key}: {this.Values}";
        }
    }
}