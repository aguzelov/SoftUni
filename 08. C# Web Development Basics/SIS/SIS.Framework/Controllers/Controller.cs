using SIS.Framework.ActionResult;
using SIS.Framework.ActionResult.Contracts;
using SIS.Framework.Models;
using SIS.Framework.Services.UserCookieServices;
using SIS.Framework.Utilities;
using SIS.Framework.Views;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses;
using SIS.HTTP.Responses.Contracts;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIS.Framework.Controllers
{
    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
        }

        public Model ModelState { get; } = new Model();

        protected ViewModel Model { get; }

        protected bool IsAuthenticatedUser { get; set; }
    
        public IHttpRequest Request { get; set; }

        private void SetMenu()
        {
            if (this.IsAuthenticatedUser)
            {
                this.Model["guestMenu"] = "d-none";
                this.Model["userMenu"] = "d-block";
            }
            else
            {
                this.Model["guestMenu"] = "d-block";
                this.Model["userMenu"] = "d-none";
            }

        }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            this.SetMenu();

            var controllerName = ControllerUtilities.GetControllerName(this);

            var fullyQualifiedName = ControllerUtilities.GetViewFullQualifiedName(controllerName, caller);

            var view = new View(fullyQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl) => new RedirectResult(redirectUrl);
    }
}