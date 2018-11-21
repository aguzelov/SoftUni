namespace Eventures.Web.Models
{
    public class ErrorViewModel
    {
        public int StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string MoreInfo => @"https://en.wikipedia.org/wiki/List_of_HTTP_status_codes#" + this.StatusCode;
    }
}