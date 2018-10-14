﻿using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;

namespace SIS.App.IRunes.App.Controllers
{
    public class BadRequestController : BaseController
    {
        public IHttpResponse NotFound(IHttpRequest request)
        {
            return this.View("notfound");
        }
    }
}