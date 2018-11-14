using Chushka.Services.Contracts;
using Chushka.Web.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chushka.Web.Controllers
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

            var result = this.usersService.Login(model.Username, model.Password);

            if (!result.Result)
            {
                return this.View();
            }

            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            var model = new RegisterUserViewModel();
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
                return this.View();

            var result = this.usersService.Register(model.Username,
                  model.Password,
                  model.ConfirmPassword,
                  model.Email,
                  model.FullName);

            if (!result.Result)
            {
                return this.View();
            }

            return this.RedirectToAction(nameof(Login));
        }
    }
}