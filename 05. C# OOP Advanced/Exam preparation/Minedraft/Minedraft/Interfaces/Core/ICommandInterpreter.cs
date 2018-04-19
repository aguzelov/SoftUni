using System.Collections.Generic;

public interface ICommandInterpreter
{
    string ProcessCommand(IList<string> args);
}