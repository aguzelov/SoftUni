using System;
using System.Collections.Generic;
using System.Linq;
using Torshia.App.Services.Contracts;
using Torshia.Data;
using Torshia.Models;

namespace Torshia.App.Services
{
    public class ReportService : IReportService
    {
        private readonly TorshiaCotnext context;
        private readonly ITaskService taskService;

        public ReportService(TorshiaCotnext context, ITaskService taskService)
        {
            this.context = context;
            this.taskService = taskService;
        }

        public bool AddReport(int userId, int taskId)
        {
            var task = this.taskService.GetTask(taskId);

            if (task == null)
            {
                return false;
            }

            task.IsReported = true;
            this.context.Update(task);
            var chance = new Random();

            var status = chance.Next(100) > 25 ? Status.Completed : Status.Archived;

            var report = new Report
            {
                ReporterdOn = DateTime.UtcNow,
                UserId = userId,
                TaskId = taskId,
                Status = status
            };

            this.context.Reports.Add(report);
            this.context.SaveChanges();

            return true;
        }

        public IEnumerable<Report> GetAll(string username)
        {
            return this.context.Reports.Where(r => r.Reporter.Username == username).ToList();
        }

        public Report GetReport(int id)
        {
            return this.context.Reports.Find(id);
        }
    }
}