using SIS.HTTP.Responses;
using System.Linq;
using Torshia.App.Services.Contracts;
using Torshia.App.ViewModels;
using Torshia.Data;

namespace Torshia.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserService userService;
        private readonly TorshiaCotnext cotnext;

        public HomeController(IUserService userService, TorshiaCotnext cotnext)
        {
            this.userService = userService;
            this.cotnext = cotnext;
        }

        public IHttpResponse Index()
        {
            var user = this.userService.GetUser(this.User.Username);
            if (user != null)
            {
                var tasks = this.cotnext.Tasks
                    .Where(t => !t.IsReported)
                    .Select(t => new HomeTaskView
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Level = t.AffectedSectors.Count().ToString()
                    }).ToList();

                var view = new HomeTasksView
                {
                    Tasks = tasks,
                };

                return this.View("Home/UserIndex", view);
            }
            else
            {
                return this.View("Home/GuestIndex");
            }
        }
    }
}