using SIS.App.IRunes.Services.PasswordServices;
using SIS.App.IRunes.Services.UserCookieServices;
using SIS.App.IRunes.Services.UserServices;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using System;

namespace SIS.App.IRunes.App.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService UserService;
        private readonly IPasswordService PasswordService;
        private readonly IUserCookieService UserCookieService;

        public UserController(IUserService userService, IPasswordService passwordService, IUserCookieService userCookieService)
        {
            this.UserService = userService;
            this.PasswordService = passwordService;
            this.UserCookieService = userCookieService;
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            if (request.RequestMethod == HttpRequestMethod.Get)
            {
                this.IsAuthenticatedUser = false;
                this.ViewData["errorDisplay"] = "none";
                return this.View("Users/Register");
            }

            var username = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString().Trim();
            var confirmPassword = request.FormData["confirm-password"].ToString().Trim();
            var email = request.FormData["email"].ToString().Trim();

            if (!IsValidUserData(username, password, confirmPassword, email))
            {
                this.IsAuthenticatedUser = false;
                this.ViewData["errorDisplay"] = "inline";
                return this.View("Users/Register");
            }

            var hashedPassword = this.PasswordService.GenerateHash(password);

            this.UserService.Add(username, hashedPassword, email);

            var response = this.View("Home/Index-user");

            var cookie = this.UserCookieService.GetUserCookie(username);

            response.Cookies.Add(cookie);

            return response;
        }

        public IHttpResponse Login(IHttpRequest request)
        {
            if (request.RequestMethod == HttpRequestMethod.Get)
            {
                this.IsAuthenticatedUser = false;
                this.ViewData["errorDisplay"] = "none";
                return this.View("Users/Login");
            }

            var username = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString().Trim();

            if (!IsValidUserData(username, password))
            {
                this.IsAuthenticatedUser = false;
                this.ViewData["errorDisplay"] = "inline";
                return this.View("Users/Login");
            }

            var hashedPassword = this.PasswordService.GenerateHash(password);

            if (!this.UserService.Exsist(username, hashedPassword))
            {
                this.IsAuthenticatedUser = false;
                this.ViewData["errorDisplay"] = "inline";
                return this.View("Users/Login");
            }

            var response = this.Redirect("/Home/Index");

            var cookie = this.UserCookieService.GetUserCookie(username);

            response.Cookies.Add(cookie);

            return response;
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            var authCookie = request.Cookies.GetCookie(HttpCookie.AuthenticeKey);
            authCookie.Expires = DateTime.UtcNow.AddDays(-1);

            var response = this.Redirect("/Home/Index");

            response.Cookies.Add(authCookie);

            return response;
        }

        private bool IsValidUserData(string username, string password, string confirmPassword, string email)
        {
            return string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) ||
                string.IsNullOrEmpty(email) ||
                password != confirmPassword
                ? false
                : true;
        }

        private bool IsValidUserData(string username, string password)
        {
            return string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password)
                ? false
                : true;
        }
    }
}