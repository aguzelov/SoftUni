using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Panda.App.Models;
using Panda.Services.Contracts;
using System.Threading.Tasks;

namespace Panda.App.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountService userService;

        public AccountsController(IAccountService userService)
        {
            this.userService = userService;
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.userService.SingOut();

            return this.Redirect("/");
        }

        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/");
            }

            this.userService.SingIn(model.Username, model.Password);

            return this.Redirect("/");
        }

        public IActionResult Register() => this.View();

        [HttpPost]
        public async Task<IActionResult> Register(RegiserUserModel model)
        {
            var isAdded = await this.userService.Add(model.Username, model.Password, model.ConfirmPassword, model.Email);

            if (!isAdded)
            {
                return this.View();
            }

            return this.Redirect("/Accounts/Login");
        }
    }
}