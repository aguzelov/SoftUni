using Employees.App.Core.Commands.Contracts;

namespace Employees.App.Core.Contracts
{
    public interface ICommandInterpreter
    {
        ICommand GetCommand(string commandName);
    }
}