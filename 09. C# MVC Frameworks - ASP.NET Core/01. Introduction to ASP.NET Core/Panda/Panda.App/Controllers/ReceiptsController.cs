using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Panda.App.Models;
using Panda.Services.Contracts;

namespace PandaWebApp.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var username = this.User.Identity.Name;

            var receipts = this.receiptsService.GetUserReceipts<ReceiptIndexDetailViewModel>(username);

            return this.View(receipts);
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var receipt = this.receiptsService.Details<ReceiptsDetailsViewModel>(id);

            return this.View(receipt);
        }
    }
}