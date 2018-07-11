namespace BusTickets.Client.Core
{
    public interface ICommandDispatcher
    {
        string DispatchCommand(string[] commandParameters);
    }
}