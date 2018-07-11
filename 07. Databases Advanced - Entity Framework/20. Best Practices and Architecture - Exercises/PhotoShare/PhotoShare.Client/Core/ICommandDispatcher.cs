namespace PhotoShare.Client.Core
{
    public interface ICommandDispatcher
    {
        string DispatchCommand(string[] commandParameters);
    }
}