using SIS.HTTP.Cookies;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using Torshia.App.Services.Contracts;
using Torshia.App.ViewModels;

namespace Torshia.App.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IHttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Login(UserLoginView view)
        {
            if (!this.userService.Validate(view))
            {
                return BadRequestErrorWithView("Invalid username or password!");
            }

            var user = this.userService.GetUser(view.Username);

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
        public IHttpResponse Register(UserRegisterView view)
        {
            if (!this.userService.Add(view))
            {
                return BadRequestErrorWithView("Invalid registration data!");
            }

            return this.Redirect("Users/Login");
        }

        [Authorize("User")]
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
    }
}