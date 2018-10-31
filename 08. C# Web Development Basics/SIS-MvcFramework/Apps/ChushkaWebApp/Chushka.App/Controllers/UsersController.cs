using Chushka.App.ViewModels;
using Chushka.Services;
using SIS.HTTP.Cookies;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace Chushka.App.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize]
        public IHttpResponse Logout()
        {
            if (!this.Request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return this.Redirect("/");
            }

            var cookie = this.Request.Cookies.GetCookie(".auth-cakes");
            cookie.Delete();
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }

        public IHttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Login(LoginUserModel model)
        {
            var isValid = this.userService.Contains(model.Username, model.Password);
            if (!isValid)
            {
                return this.BadRequestErrorWithView("Invalid username or password.");
            }

            var user = this.userService.GetUser(model.Username);

            var mvcUser = new MvcUserInfo
            {
                Username = user.Username,
                Role = user.Role.ToString(),
                Info = user.Email
            };
            var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);

            var cookie = new HttpCookie(".auth-cakes", cookieContent, 7)
            {
                HttpOnly = true
            };

            this.Response.Cookies.Add(cookie);

            return this.Redirect("/");
        }

        public IHttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Register(RegiserUserModel model)
        {
            var isAdded = this.userService.Add(model.Username, model.Password, model.ConfirmPassword, model.Email);

            if (!isAdded)
            {
                return this.BadRequestErrorWithView("Invalid registration data!");
            }

            return this.Redirect("/Users/Login");
        }
    }
}