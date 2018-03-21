using Logging.Interfaces;

namespace Logging.Appenders
{
    public class FileAppender : Appender
    {
        private static int messageAppendedCount = 0;

        public FileAppender(ILayout layout) : base(layout)
        {
        }

        public LogFile File { get; set; }

        public override void Append(IReport report)
        {
            if (this.ReportLevel > report.ReportLevel) return;

            string text = base.layout.GetFormat(report);

            this.File.Write(text);

            messageAppendedCount++;
        }

        public override string ToString()
        {
            return base.ToString() + $"{messageAppendedCount}, File size:{this.File.Size}";
        }
    }
}