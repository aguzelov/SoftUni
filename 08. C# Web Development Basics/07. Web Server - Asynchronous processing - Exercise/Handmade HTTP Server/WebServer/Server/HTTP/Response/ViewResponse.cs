using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Contracts;
using WebServer.Server.Enums;

namespace WebServer.Server.HTTP.Response
{
    public class ViewResponse : HttpResponse
    {
        public ViewResponse(HttpStatusCode responseCode, IView view) : base(responseCode, view)
        {
        }
    }
}