using System;
using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Utilities;

namespace TeamBuilder.App.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] commandArg)
        {
            Check.CheckLength(0, commandArg);

            Environment.Exit(0);

            return string.Empty;
        }
    }
}