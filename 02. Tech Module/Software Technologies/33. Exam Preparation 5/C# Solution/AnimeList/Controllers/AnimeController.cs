using System.Linq;
using System.Web.Mvc;
using AnimeList.Models;
using System.Collections.Generic;

namespace AnimeList.Controllers
{
    [ValidateInput(false)]
    public class AnimeController : Controller
    {
        private AnimeListDbContext db = new AnimeListDbContext();

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            List<Anime> animes = db.Animes.ToList();

            return View(animes);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Anime anime)
        {
            if (this.ModelState.IsValid)
            {

                db.Animes.Add(anime);
                db.SaveChanges();
                return Redirect("/");
            }
            return View(anime);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            var anime = db.Animes.Find(id);
            if(anime == null)
            {
                return HttpNotFound();
            }
            return View(anime);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Anime animeModel)
        {
            var anime = db.Animes.Find(id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            db.Animes.Remove(anime);
            db.SaveChanges();
            return Redirect("/");
        }
    }
}