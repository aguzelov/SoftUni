using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Server.HTTP.Response
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl) : base(redirectUrl)
        {
        }
    }
}