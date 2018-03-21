using Logging.Interfaces;
using System;

namespace Logging.Layouts
{
    public class XmlLayout : ILayout
    {
        private string format = "<log>" + Environment.NewLine +
                                "    <date>{0}</date>" + Environment.NewLine +
                                "    <level>{1}</level>" + Environment.NewLine +
                                "    <message>{2}</message>" + Environment.NewLine +
                                "</log>";

        public string GetFormat(IReport report)
        {
            return String.Format(this.format, report.Date, report.ReportLevel, report.Message);
        }
    }
}