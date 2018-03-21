namespace Logging.Interfaces
{
    public interface IReport
    {
        string Date { get; }
        ReportLevel ReportLevel { get; }
        string Message { get; }
    }
}