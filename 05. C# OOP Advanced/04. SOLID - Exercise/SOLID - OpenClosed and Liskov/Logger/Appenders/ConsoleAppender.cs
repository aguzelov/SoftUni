using Logging.Interfaces;
using System;

namespace Logging.Appenders
{
    public class ConsoleAppender : Appender
    {
        private static int messageAppendedCount = 0;

        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(IReport report)
        {
            if (this.ReportLevel > report.ReportLevel) return;

            Console.WriteLine(base.layout.GetFormat(report));

            messageAppendedCount++;
        }

        public override string ToString()
        {
            return base.ToString() + $"{messageAppendedCount}";
        }
    }
}