using SIS.HTTP.Enums;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.Services.PasswordServices;
using SIS.Services.UserCookieServices;
using SIS.Services.UserServices;

namespace SIS.App.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService UserService;
        private readonly IPasswordService PasswordService;
        private readonly IUserCookieService UserCookieService;

        public AccountController(IUserService userService, IPasswordService passwordService, IUserCookieService userCookieService)
        {
            this.UserService = userService;
            this.PasswordService = passwordService;
            this.UserCookieService = userCookieService;
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            if (request.RequestMethod == HttpRequestMethod.Get)
            {
                return this.View("register");
            }

            var fullName = request.FormData["fullName"].ToString().Trim();
            var username = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString().Trim();
            var confirmPassword = request.FormData["confirm-password"].ToString().Trim();

            if (!IsValidUserData(fullName, username, password, confirmPassword))
            {
                return this.View("register");
            }

            var hashedPassword = this.PasswordService.GenerateHash(password);

            this.UserService.Add(fullName, username, hashedPassword);

            var response = this.Redirect("/");

            var cookie = this.UserCookieService.GetUserCookie(username);

            response.Cookies.Add(cookie);

            return response;
        }

        public IHttpResponse Login(IHttpRequest request)
        {
            if (request.RequestMethod == HttpRequestMethod.Get)
            {
                return this.View("login");
            }

            var username = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString().Trim();

            if (!IsValidUserData(username, password))
            {
                return this.View("login");
            }

            var hashedPassword = this.PasswordService.GenerateHash(password);

            if (!this.UserService.Exsist(username, hashedPassword))
            {
                return this.Redirect("/register");
            }

            var response = this.Redirect("/");

            var cookie = this.UserCookieService.GetUserCookie(username);

            response.Cookies.Add(cookie);

            return response;
        }

        public IHttpResponse Profile(IHttpRequest request)
        {
            var username = this.UserCookieService.GetUsername(request.Cookies);

            var user = this.UserService.Get(username);

            if (user == null)
            {
                return this.Redirect("/");
            }

            this.ViewData.Add("username", user.Name);
            this.ViewData.Add("registrationDate", user.DateOfRegistration.ToString("dd-MM-yyyy"));
            this.ViewData.Add("orders", user.Orders.Count.ToString());

            return this.View("/profile");
        }

        private bool IsValidUserData(string fullName, string username, string password, string confirmPassword)
        {
            return string.IsNullOrEmpty(fullName) ||
                string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) ||
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