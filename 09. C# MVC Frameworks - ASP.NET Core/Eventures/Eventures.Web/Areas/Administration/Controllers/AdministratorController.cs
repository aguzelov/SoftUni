using Eventures.Services.Contracts;
using Eventures.Web.Areas.Administration.Models;
using Eventures.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventures.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class AdministratorController : Controller
    {
        private readonly IUsersService _usersService;

        public AdministratorController(IUsersService usersService)
        {
            this._usersService = usersService;
        }

        public IActionResult UserAdministration()
        {
            var model = new UsersByRoleViewModel<AdminUsersViewModel>
            {
                Administrators = this._usersService.All<AdminUsersViewModel>(GlobalConstants.AdminRole),
                Users = this._usersService.All<AdminUsersViewModel>(GlobalConstants.UserRole)
            };

            return this.View(model);
        }

        public async Task<IActionResult> Promote(string id)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(UserAdministration));
            }

            await this._usersService.Promote(id);

            return this.RedirectToAction(nameof(UserAdministration));
        }

        public async Task<IActionResult> Demote(string id)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(UserAdministration));
            }

            await this._usersService.Demote(id);

            return this.RedirectToAction(nameof(UserAdministration));
        }
    }
}