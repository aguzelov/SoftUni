using Logging.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logging.Loggers
{
    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders.ToList();
        }

        public void Append(IReport report)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(report);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Logger info");
            foreach (var appender in appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString();
        }
    }
}