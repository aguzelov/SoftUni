using Employees.App.Core.Commands.Contracts;
using System;

namespace Employees.App.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public void Execute(string[] data)
        {
            Environment.Exit(0);
        }
    }
}