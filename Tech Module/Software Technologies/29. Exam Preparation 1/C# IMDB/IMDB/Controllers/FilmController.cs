using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMDB.Models;

namespace IMDB.Controllers
{
    [ValidateInput(false)]
    public class FilmController : Controller
    {
        private IMDBDbContext db = new IMDBDbContext();

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var films = db.Films.ToList();
            return View(films);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View(new Film());
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {
                db.Films.Add(film);
                db.SaveChanges();
                return Redirect("/");
            }

            return View(film);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var film = db.Films.Find(id);
            if (film == null)
            {
                return new HttpNotFoundResult();
            }

            return View(film);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Film filmModel)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var filmFromDb = db.Films.Find(id);
            if (filmFromDb == null)
            {
                return new HttpNotFoundResult();
            }

            if (ModelState.IsValid)
            {
                filmFromDb.Name = filmModel.Name;
                filmFromDb.Genre = filmModel.Genre;
                filmFromDb.Director = filmModel.Director;
                filmFromDb.Year = filmModel.Year;

                db.SaveChanges();

                return Redirect("/");
            }

            return View("Edit", filmModel);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var film = db.Films.Find(id);
            if (film == null)
            {
                return new HttpNotFoundResult();
            }

            return View(film);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Film filmModel)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var filmFromDb = db.Films.Find(id);
            if (filmFromDb == null)
            {
                return new HttpNotFoundResult();
            }


            db.Films.Remove(filmFromDb);

            db.SaveChanges();

            return Redirect("/");
        }
    }
}