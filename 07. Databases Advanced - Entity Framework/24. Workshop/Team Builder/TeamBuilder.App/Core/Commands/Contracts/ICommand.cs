namespace TeamBuilder.App.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(string[] commandArg);
    }
}