using Chushka.Models;
using Chushka.Services.Contracts;
using Chushka.Web.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Chushka.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var types = Enum.GetNames(typeof(ProductType)).ToList();

            var model = new CreateProductViewModel();
            model.Types = types;

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var id = this.productsService.Create(
                 model.Name,
                 model.Price,
                 model.Description,
                 model.Type);

            return this.RedirectToAction(nameof(Details), routeValues: id);
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var model = this.productsService.Details<DetailsProductViewModel>(id);

            if (model == null)
                return this.Redirect("/");

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string id)
        {
            var model = this.productsService.Details<CreateProductViewModel>(id);

            var types = Enum.GetNames(typeof(ProductType)).ToList();
            model.Types = types;

            if (model == null)
                return this.Redirect("/");

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
                return this.Redirect("/");

            var isEdited = this.productsService.Edit(
                 model.Id,
                  model.Name,
                  model.Price,
                  model.Description,
                  model.Type);

            if (!isEdited)
                return this.Redirect("/");

            return this.RedirectToAction(nameof(Details), routeValues: model.Id);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            var model = this.productsService.Details<CreateProductViewModel>(id);

            var types = Enum.GetNames(typeof(ProductType)).ToList();
            model.Types = types;

            if (model == null)
                return this.Redirect("/");

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(CreateProductViewModel model)
        {
            if (model.Id == null)
                return this.Redirect("/");

            this.productsService.Delete(model.Id);

            return this.Redirect("/");
        }
    }
}