using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System.Linq;
using Torshia.App.Services.Contracts;
using Torshia.App.ViewModels;

namespace Torshia.App.Controllers
{
    public class ReportsController : BaseController
    {
        private readonly IReportService reportService;

        public ReportsController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [Authorize("Admin")]
        public IHttpResponse All()
        {
            var reports = this.reportService.GetAll(this.User.Username)
                .Select(r => new ReportView
                {
                    Id = r.Id,
                    Title = r.Task.Title,
                    Level = r.Task.AffectedSectors.Count.ToString(),
                    Status = r.Status.ToString()
                }).ToList();

            var view = new ReportsView
            {
                Reports = reports
            };

            return this.View("/Reports/All", view);
        }

        [Authorize("Admin")]
        public IHttpResponse Details(int id)
        {
            var report = this.reportService.GetReport(id);

            if (report == null)
            {
                return BadRequestErrorWithView("Invalid report id!");
            }

            var view = new ReportDetailView
            {
                Id = report.Id,
                TaskTitle = report.Task.Title,
                TaskLevel = report.Task.AffectedSectors.Count.ToString(),
                Status = report.Status.ToString(),
                Date = report.Task.DueDate.ToString("dd/MM/yyyy"),
                ReportedOn = report.ReporterdOn.ToString("dd/MM/yyyy"),
                Reporter = report.Reporter.Username,
                TaskParticipants = string.Join(", ", report.Task.Participants.Select(p => p.User.Username).ToList()),
                Sectors = string.Join(", ", report.Task.AffectedSectors.Select(s => s.Sector.ToString())),
                TaskDescription = report.Task.Description
            };

            return this.View("/Reports/Details", view);
        }
    }
}