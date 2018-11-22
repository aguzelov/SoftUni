using Eventures.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Error()
        {
            var statusCode = this.HttpContext.Response.StatusCode;
            var statusMessage = string.Empty;
            switch (statusCode)
            {
                case 400:
                    statusMessage = "Bad request: The request cannot be fulfilled due to bad syntax";
                    break;

                case 403:
                    statusMessage = "Forbidden";
                    break;

                case 404:
                    statusMessage = "Page not found";
                    break;

                case 408:
                    statusMessage = "The server timed out waiting for the request";
                    break;

                case 500:
                    statusMessage = "Internal Server Error - server was unable to finish processing the request";
                    break;

                default:
                    statusMessage = "That’s odd... Something we didn't expect happened";
                    break;
            }

            var model = new ErrorViewModel
            {
                StatusCode = statusCode,
                StatusMessage = statusMessage
            };

            return this.View(model);
        }
    }
}