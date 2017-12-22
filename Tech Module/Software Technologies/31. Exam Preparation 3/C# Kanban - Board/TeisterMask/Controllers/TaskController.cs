using System;
using System.Linq;
using System.Web.Mvc;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
    [ValidateInput(false)]
    public class TaskController : Controller
    {
        private TeisterMaskDbContext db = new TeisterMaskDbContext();

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var tasks = db.Tasks.ToList();
            return View(tasks);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View(new Task());
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task task)
        {
            if (this.ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return Redirect("/");
            }
            return View(task);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            var task = db.Tasks.Find(id);
            if(task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Task taskModel)
        {
            var task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }

            if (this.ModelState.IsValid)
            {
                task.Title = taskModel.Title;
                task.Status = taskModel.Status;

                db.SaveChanges();
                return Redirect("/");
            }

            return View("Edit", taskModel);
        }

    }
}