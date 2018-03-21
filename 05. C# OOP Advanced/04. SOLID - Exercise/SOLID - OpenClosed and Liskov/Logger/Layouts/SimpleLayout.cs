using Logging.Interfaces;

namespace Logging.Layouts
{
    public class SimpleLayout : ILayout
    {
        private string format = "{0} - {1} - {2}";

        public string GetFormat(IReport report)
        {
            return string.Format(format, report.Date, report.ReportLevel, report.Message);
        }
    }
}