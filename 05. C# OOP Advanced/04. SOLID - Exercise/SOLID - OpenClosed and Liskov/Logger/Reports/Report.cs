using Logging.Interfaces;

namespace Logging.Reports
{
    public class Report : IReport
    {
        public Report(ReportLevel reportLevel, string date, string message)
        {
            ReportLevel = reportLevel;
            Date = date;
            Message = message;
        }

        public string Date { get; }
        public ReportLevel ReportLevel { get; }
        public string Message { get; }
    }
}