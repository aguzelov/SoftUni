namespace TeamBuilder.App.Core.Contracts
{
    public interface IDispatcher
    {
        string Dispatch(string commandArgs);
    }
}