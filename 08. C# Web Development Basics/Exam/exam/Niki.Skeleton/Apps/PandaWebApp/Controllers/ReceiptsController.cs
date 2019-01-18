using PandaWebApp.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaWebApp.Controllers
{
    public class ReceiptsController : BaseController
    {
        [Authorize]
        public IHttpResponse Index()
        {
            var receipts = this.Db.Receipts
                .Where(r => r.Recipient.Username == this.User.Username)
                .Select(r => new ReceiptIndexDetailViewModel
                {
                    Id = r.Id,
                    Fee = r.Fee,
                    IssuedOn = r.IssuedOn.ToString("dd/MM/yyyy"),
                    Recipient = r.Recipient.Username
                }).ToList();

            var view = new ReceiptsIndexViewModel
            {
                Receipts = receipts
            };

            return this.View(view);
        }

        [Authorize]
        public IHttpResponse Details(int id)
        {
            var receipt = this.Db.Receipts.FirstOrDefault(r => r.Id == id);

            var view = new ReceiptsDetailsViewModel
            {
                Id = receipt.Id,
                Address = receipt.Package.ShippingAddress,
                Description = receipt.Package.Description,
                IssuedOn = receipt.IssuedOn.ToString("dd/MM/yyyy"),
                Recipient = receipt.Recipient.Username,
                Weight = receipt.Package.Weight,
                Total = receipt.Fee
            };

            return this.View(view);
        }
    }
}