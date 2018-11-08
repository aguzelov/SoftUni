using AutoMapper;
using FDMC.App.Models;
using FDMC.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FDMC.App.Controllers
{
    public class CatsController : Controller
    {
        private readonly ICatService catService;
        private readonly IMapper mapper;

        public CatsController(ICatService catService, IMapper mapper)
        {
            this.catService = catService;
            this.mapper = mapper;
        }

        public IActionResult Details(int id)
        {
            var cat = this.catService.GetById<CatDetailsViewModel>(id);

            if (cat == null)
            {
                return this.Redirect("/");
            }

            return this.View(cat);
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddCatViewModel model)
        {
            var isSucceeded = this.catService.Add(model.Name, model.Age, model.Breed, model.ImageUrl);

            if (!isSucceeded)
                return this.View();

            return this.Redirect("/");
        }
    }
}