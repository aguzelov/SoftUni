using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Web.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eventures.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UsersController(IUsersService usersService, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.usersService = usersService;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [Authorize]
        public IActionResult Logout()
        {
            this.usersService.Logout();
            return this.Redirect("/");
        }

        public IActionResult Login() => this.View();

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Login(LoginUserViewModel model)
        {
            var returnUrl = "/";

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = this.usersService.Login(model.Username, model.Password, model.RememberMe);

            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            return this.Redirect(returnUrl);
        }

        public IActionResult Register() => this.View();

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = this.usersService.Register(model.Username, model.Email, model.Password, model.ConfirmPassword, model.FirstName, model.LastName, model.UniqueCitizenNumber).GetAwaiter().GetResult();

            if (!result)
            {
                return this.View(model);
            }

            return this.RedirectToAction(nameof(Login));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider)
        {
            var returnUrl = "/";
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Users", new { returnUrl });
            var properties = this.signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToAction(nameof(Login));
            }
            var info = await this.signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await this.signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                return this.RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await this.signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    throw new ApplicationException("Error loading external login information during confirmation.");
                }
                var user = new User { UserName = model.Email, Email = model.Email };
                var result = await this.userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    if (this.userManager.Users.Count() == 1)
                    {
                        await this.userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await this.userManager.AddToRoleAsync(user, "User");
                    }

                    result = await this.userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await this.signInManager.SignInAsync(user, isPersistent: false);
                        return this.RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(nameof(ExternalLogin), model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}