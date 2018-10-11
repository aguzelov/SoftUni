using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responses;

namespace SIS.WebServer.Results
{
    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location, HttpResponseStatusCode responseStatusCode)
           : base(responseStatusCode)
        {
            this.Headers.Add(new HttpHeader("Location", location));
        }
    }
}