namespace PhotoShare.Client.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(params string[] data);
    }
}