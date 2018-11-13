using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Panda.App.Models;
using Panda.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Panda.App.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackageService packageService;
        private readonly IAccountService accountService;

        public PackagesController(IPackageService packageService, IAccountService accountService)
        {
            this.packageService = packageService;
            this.accountService = accountService;
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var model = this.packageService.GetById<PackageDetailsViewModel>(id);

            if (model == null) return this.Redirect("/");

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var au = this.User.Identity.AuthenticationType;
            var claims = this.User.Claims.ToList();
            var isAu = this.User.Identity.IsAuthenticated;

            var recipients = this.accountService.GetAllUsersUsername();

            return this.View(recipients);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(PackageGreateViewModel view)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var packageId = this.packageService.Add(view.Description, view.ShippingAddress, view.Weight, view.Recipient);

            if (packageId == null)
            {
                return this.View();
            }

            return this.Redirect($"/Packages/Details?id={packageId}");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Pending()
        {
            var packages = this.packageService.GetPackagesByStatus<PackageDetailsViewModel>("Pending");
            this.ViewData["Type"] = "Pending";

            return this.View("All", packages);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Shipped()
        {
            var packages = this.packageService.GetPackagesByStatus<PackageDetailsViewModel>("Shipped");

            this.ViewData["Type"] = "Shipped";

            return this.View("All", packages);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delivered()
        {
            var packages = this.packageService.GetPackagesByStatus<PackageDetailsViewModel>("Delivered");
            this.ViewData["Type"] = "Delivered";

            return this.View("All", packages);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Ship(string id)
        {
            var isSucceeded = this.packageService.Ship(id);

            if (!isSucceeded)
            {
                return Redirect("/");
            }

            return this.Redirect($"/Packages/Details?id={id}");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Deliver(string id)
        {
            bool isSucceeded = this.packageService.Deliver(id);

            if (!isSucceeded)
            {
                return Redirect("/");
            }

            return this.Redirect($"/Packages/Details?id={id}");
        }

        [Authorize]
        public IActionResult Acquire(string id)
        {
            this.packageService.Acquire(id);

            return this.Redirect("/");
        }
    }

    public class UserNames
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}