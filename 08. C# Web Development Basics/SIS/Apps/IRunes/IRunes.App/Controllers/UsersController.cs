using IRunes.Services.PasswordServices;
using IRunes.Services.UserServices;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Services.UserCookieServices;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using System;
using SIS.Framework.ActionsResults.Base;
using SIS.Framework.Security;
using SIS.HTTP.Requests;

namespace IRunes.App.Controllers
{
    public class UsersController : BaseController
    {
        private const string RegisterPage = "Register";
        private const string LoginPage = "Login";
        private readonly IUserService UserService;
        private readonly IHashService HashService;

        public UsersController(IUserService userService, IHashService hashService)
        : base()
        {
            this.UserService = userService;
            this.HashService = hashService;
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Register()
        {
            if (this.Request.RequestMethod == HttpRequestMethod.Get)
            {
                this.ViewModel["errorDisplay"] = "none";
                return this.View(RegisterPage);
            }

            var username = this.Request.FormData["username"].ToString().Trim();
            var password = this.Request.FormData["password"].ToString().Trim();
            var confirmPassword = this.Request.FormData["confirm-password"].ToString().Trim();
            var email = this.Request.FormData["email"].ToString().Trim();

            if (!IsValidUserData(username, password, confirmPassword, email))
            {
                this.ViewModel["errorDisplay"] = "inline";
                return this.View(RegisterPage);
            }

            var hashedPassword = this.HashService.GenerateHash(password);

            this.UserService.Add(username, hashedPassword, email);

            this.SignIn(new IdentityUser { Username = username, Password = hashedPassword });

            return this.View("Index-user");
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Login()
        {
            if (this.Request.RequestMethod == HttpRequestMethod.Get)
            {
                this.ViewModel["errorDisplay"] = "none";
                return this.View(LoginPage);
            }

            var username = this.Request.FormData["username"].ToString().Trim();
            var password = this.Request.FormData["password"].ToString().Trim();

            if (!IsValidUserData(username, password))
            {
                this.ViewModel["errorDisplay"] = "inline";
                return this.View(LoginPage);
            }

            var hashedPassword = this.HashService.GenerateHash(password);

            if (!this.UserService.Exsist(username, hashedPassword))
            {
                this.ViewModel["errorDisplay"] = "inline";
                return this.View(LoginPage);
            }

            this.SignIn(new IdentityUser { Username = username, Password = hashedPassword });

            return this.RedirectToAction("/Home/Index"); ;
        }

        [HttpGet]
        public IActionResult Logout(IHttpRequest request)
        {
            this.SignOut();

            return this.RedirectToAction("/Home/Index"); ;
        }

        private bool IsValidUserData(string username, string password, string confirmPassword, string email)
        {
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(confirmPassword) && !string.IsNullOrEmpty(email) && password == confirmPassword;
        }

        private bool IsValidUserData(string username, string password)
        {
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }
    }
}