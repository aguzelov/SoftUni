using System.Collections.Generic;

namespace Iterator.Contracts
{
    public interface IInterpreter
    {
        ICommand ParseCommand(List<string> args);
    }
}