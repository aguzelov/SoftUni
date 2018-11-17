using Eventures.Services.Contracts;
using Eventures.Web.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.usersService.Logout();
            return this.Redirect("/");
        }

        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var result = this.usersService.Login(model.Username, model.Password, model.RememberMe);

            if (!result)
            {
                return this.View();
            }

            return this.Redirect("/");
        }

        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var result = this.usersService.Register(model.Username, model.Email, model.Password, model.ConfirmPassword, model.FirstName, model.LastName, model.UniqueCitizenNumber).GetAwaiter().GetResult();

            if (!result)
            {
                return this.View();
            }

            return this.RedirectToAction(nameof(Login));
        }
    }
}