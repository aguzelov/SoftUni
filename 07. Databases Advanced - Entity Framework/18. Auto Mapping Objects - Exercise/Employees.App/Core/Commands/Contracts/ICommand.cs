namespace Employees.App.Core.Commands.Contracts
{
    public interface ICommand
    {
        void Execute(string[] data);
    }
}