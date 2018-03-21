namespace Logging.Interfaces
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        void Append(IReport report);

        string ToString();
    }
}