using PandaWebApp.Models;
using PandaWebApp.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaWebApp.Controllers
{
    public class PackagesController : BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var package = this.Db.Packages.FirstOrDefault(p => p.Id == id);

            var estimatedDeliveryDate = GetDeliveryDate(package);

            var view = new PackageDetailsViewModel
            {
                Address = package.ShippingAddress,
                Status = package.Status.ToString(),
                EstimatedDeliveryDate = estimatedDeliveryDate,
                Weight = package.Weight,
                Recipient = package.Recipient.Username,
                Description = package.Description
            };

            return this.View(view);
        }

        [Authorize("Admin")]
        [HttpGet]
        public IHttpResponse Create()
        {
            var recipients = this.Db.Users
                .Select(u => u.Username).ToList();

            var view = new PackagesCreateUsernamesViewModel
            {
                Users = recipients
            };

            return this.View(view);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Create(CreatePackageViewModel view)
        {
            //Validate

            if (view.Description == null ||
                view.Recipient == null ||
                view.ShippingAddress == null ||
                view.Weight == null)
            {
                return BadRequestErrorWithView("Invalid package data!");
            }

            var user = this.Db.Users.FirstOrDefault(u => u.Username == view.Recipient);
            if (user == null)
            {
                return BadRequestErrorWithView("Invalid package data!");
            }

            var package = new Package
            {
                Status = Status.Pending,
                EstimatedDeliveryDate = null,
                Description = view.Description,
                ShippingAddress = view.ShippingAddress,
                Weight = float.Parse(view.Weight),
                UserId = user.Id
            };

            this.Db.Packages.Add(package);
            this.Db.SaveChanges();

            return this.Redirect($"/Packages/Details?id={package.Id}");
        }

        [Authorize("Admin")]
        public IHttpResponse Pending()
        {
            return GetPackagesByStatus("Pending");
        }

        [Authorize("Admin")]
        public IHttpResponse Shipped()
        {
            return GetPackagesByStatus("Shipped");
        }

        [Authorize("Admin")]
        public IHttpResponse Delivered()
        {
            return GetPackagesByStatus("Delivered");
        }

        [Authorize("Admin")]
        public IHttpResponse Ship(int id)
        {
            var package = this.Db.Packages.FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                return Redirect("/");
            }

            package.Status = Status.Shipped;

            var random = new Random();

            package.EstimatedDeliveryDate = DateTime.Now.AddDays(random.Next(20, 40));

            this.Db.SaveChanges();

            return this.Redirect($"/Packages/Details?id={package.Id}");
        }

        [Authorize("Admin")]
        public IHttpResponse Deliver(int id)
        {
            var package = this.Db.Packages.FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                return Redirect("/");
            }

            package.Status = Status.Delivered;

            this.Db.SaveChanges();

            return this.Redirect($"/Packages/Details?id={package.Id}");
        }

        [Authorize]
        public IHttpResponse Acquire(int id)
        {
            var package = this.Db.Packages.FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                return Redirect("/");
            }

            package.Status = Status.Acquired;

            var fee = (decimal)(package.Weight * 2.67);

            var receipt = new Receipt
            {
                PackageId = package.Id,
                UserId = package.UserId,
                Fee = fee,
                IssuedOn = DateTime.UtcNow
            };

            this.Db.Receipts.Add(receipt);

            this.Db.SaveChanges();

            return this.Redirect("/");
        }

        private IHttpResponse GetPackagesByStatus(string status)
        {
            IQueryable<Package> query = null;
            if (status == "Delivered")
            {
                query = this.Db.Packages
                .Where(p => p.Status.ToString() == status ||
                    p.Status.ToString() == "Acquired");
            }
            else
            {
                query = this.Db.Packages
                   .Where(p => p.Status.ToString() == status);
            }

            var packages = query
                .Select(p => new PackagetAllDetailsViewModel
                {
                    Id = p.Id,
                    Description = p.Description,
                    Address = p.ShippingAddress,
                    EstimatedDeliveryDate = p.EstimatedDeliveryDate != null ? p.EstimatedDeliveryDate.Value.ToString("dd/MM/yyyy") : "N/A",
                    Recipient = p.Recipient.Username,
                    Weight = p.Weight
                }).ToList();

            var view = new PackagesAllViewModel
            {
                Type = status,
                Packages = packages
            };

            return this.View("/Packages/All", view);
        }

        private string GetDeliveryDate(Package package)
        {
            if (package.Status == Status.Pending)
            {
                return "N/A";
            }
            else if (package.Status == Status.Shipped)
            {
                return package.EstimatedDeliveryDate.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                return "Delivered";
            }
        }
    }
}