namespace SIS.HTTP.Headers
{
    public class HttpHeader
    {
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