using System.Collections.Generic;
using Torshia.Models;

namespace Torshia.App.Services.Contracts
{
    public interface IReportService
    {
        bool AddReport(int userId, int taskId);

        IEnumerable<Report> GetAll(string username);

        Report GetReport(int id);
    }
}