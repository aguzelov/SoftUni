namespace Logging.Interfaces
{
    public interface ILogger
    {
        void Append(IReport report);

        string ToString();
    }
}