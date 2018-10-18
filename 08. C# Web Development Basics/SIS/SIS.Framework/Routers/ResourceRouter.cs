using SIS.HTTP.Enums;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Api;
using SIS.WebServer.Results;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace SIS.Framework.Routers
{
    public class ResourceRouter : IHandleable
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            IHttpResponse resource = ReturnIfResource(request.Path);
            return resource;
        }

        private IHttpResponse ReturnIfResource(string path)
        {
            var fullPath = Environment.CurrentDirectory + path;

            if (File.Exists(fullPath))
            {
                var extension = path.Split(".", StringSplitOptions.RemoveEmptyEntries).Last();

                var contentString = File.ReadAllText(fullPath);
                var contentBytes = Encoding.UTF8.GetBytes(contentString);

                return new InlineResourceRasult(contentBytes, HttpResponseStatusCode.OK, extension);
            }

            return null;
        }
    }
}