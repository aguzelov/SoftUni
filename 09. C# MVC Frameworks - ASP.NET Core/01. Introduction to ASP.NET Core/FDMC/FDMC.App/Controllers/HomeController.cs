using FDMC.App.Models;
using FDMC.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FDMC.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICatService catService;

        public HomeController(ICatService catService)
        {
            this.catService = catService;
        }

        public IActionResult Index()
        {
            var cats = this.catService.All<CatViewModel>();

            var model = new CatsViewModel
            {
                Cats = cats
            };

            return this.View(model);
        }
    }
}