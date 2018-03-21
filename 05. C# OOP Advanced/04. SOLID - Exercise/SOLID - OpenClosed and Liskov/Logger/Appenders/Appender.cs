using Logging.Interfaces;

namespace Logging.Appenders
{
    public abstract class Appender : IAppender
    {
        protected readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; } = ReportLevel.INFO;

        public abstract void Append(IReport report);

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ReportLevel.ToString()}, Messages appended: ";
        }
    }
}