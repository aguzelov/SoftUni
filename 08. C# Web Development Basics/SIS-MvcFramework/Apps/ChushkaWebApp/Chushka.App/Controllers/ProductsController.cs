using Chushka.App.Models;
using Chushka.App.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Linq;

namespace Chushka.App.Controllers
{
    public class ProductsController : BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var product = this.Db.Products
                .Where(p => p.Id == id && !p.IsDeleted)
                .Select(p =>
                new ProductDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Type = p.Type.ToString()
                })
                .FirstOrDefault();

            if (product == null)
            {
                return this.Redirect("/");
            }

            return this.View(product);
        }

        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Create(ProductCreateViewModel model)
        {
            if (model.Name == null ||
                model.Description == null ||
                model.Type == null ||
                model.Price < 0)
            {
                return BadRequestErrorWithView("Invalid product data!");
            }

            var isParsed = Enum.TryParse<ProductType>(model.Type, out ProductType type);

            if (!isParsed)
            {
                return BadRequestErrorWithView("Invalid product type!");
            }

            var product = this.Db.Products.Add(new Product
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Type = type
            });
            this.Db.SaveChanges();

            return this.Redirect($"/Products/Details?id={product.Entity.Id}");
        }

        [Authorize("Admin")]
        public IHttpResponse Edit(int id)
        {
            var model = this.Db.Products.Where(p => p.Id == id)
                .Select(p => new ProductEditDeleteViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    Type = p.Type.ToString()
                })
                .FirstOrDefault();

            if (model == null)
            {
                return this.Redirect("/");
            }

            return this.View(model);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Edit(ProductEditDeleteViewModel model)
        {
            var product = this.Db.Products.FirstOrDefault(p => p.Id == model.Id);

            if (product == null)
            {
                return this.Redirect("/");
            }

            var isParsed = Enum.TryParse<ProductType>(model.Type, out ProductType type);

            if (!isParsed)
            {
                return BadRequestErrorWithView("Invalid product type!");
            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Type = type;

            this.Db.SaveChanges();

            return this.Redirect($"/Products/Details?id={product.Id}");
        }

        [Authorize("Admin")]
        public IHttpResponse Delete(int id)
        {
            var model = this.Db.Products.Where(p => p.Id == id)
                .Select(p => new ProductEditDeleteViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    Type = p.Type.ToString()
                })
                .FirstOrDefault();

            if (model == null)
            {
                return this.Redirect("/");
            }

            return this.View(model);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Delete(ProductEditDeleteViewModel model)
        {
            var product = this.Db.Products.FirstOrDefault(p => p.Id == model.Id);

            if (product == null)
            {
                return this.Redirect("/");
            }

            if (product.IsDeleted)
            {
                return this.Redirect("/");
            }

            product.IsDeleted = true;

            this.Db.SaveChanges();

            return this.Redirect("/");
        }
    }
}