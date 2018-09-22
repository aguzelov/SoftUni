﻿using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.HTTP.Contracts;

namespace WebServer.Server.Handlers
{
    public class PostHandler : RequestHandler
    {
        public PostHandler(Func<IHttpRequest, IHttpResponse> handlingFunc) : base(handlingFunc)
        {
        }
    }
}