using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System.Linq;
using Torshia.App.Services.Contracts;
using Torshia.App.ViewModels;

namespace Torshia.App.Controllers
{
    public class TasksController : BaseController
    {
        private readonly ITaskService taskService;
        private readonly IUserService userService;
        private readonly IReportService reportService;

        public TasksController(ITaskService taskService, IUserService userService, IReportService reportService)
        {
            this.taskService = taskService;
            this.userService = userService;
            this.reportService = reportService;
        }

        [HttpGet]
        [Authorize("User")]
        public IHttpResponse Create()
        {
            return this.View("/Tasks/Create");
        }

        [HttpPost]
        [Authorize("Admin")]
        public IHttpResponse Create(CreateTaskView view)
        {
            var task = this.taskService.AddTask(view);
            if (task == null)
            {
                return BadRequestErrorWithView("Incorect task data!");
            }

            return this.Redirect($"/Tasks/Details?id={task.Id}");
        }

        [Authorize("User")]
        public IHttpResponse Details(int id)
        {
            var task = this.taskService.GetTask(id);

            if (task == null)
            {
                return BadRequestErrorWithView("Invalid task id!");
            }

            var model = new TaskDetailView
            {
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate.ToString("dd/MM/yyyy"),
                Level = task.AffectedSectors.Count().ToString(),
                Participants = task.Participants.Select(p => p.User.Username).ToList()
            };

            return this.View("/Tasks/Details", model);
        }

        [Authorize("User")]
        public IHttpResponse Report(int id)
        {
            var user = this.userService.GetUser(this.User.Username);

            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.reportService.AddReport(user.Id, id))
            {
                return BadRequestErrorWithView("Report is failed!");
            }

            return this.Redirect("/Reports/All");
        }
    }
}