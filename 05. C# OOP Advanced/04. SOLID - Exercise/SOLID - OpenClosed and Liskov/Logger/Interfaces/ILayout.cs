namespace Logging.Interfaces
{
    public interface ILayout
    {
        string GetFormat(IReport report);
    }
}