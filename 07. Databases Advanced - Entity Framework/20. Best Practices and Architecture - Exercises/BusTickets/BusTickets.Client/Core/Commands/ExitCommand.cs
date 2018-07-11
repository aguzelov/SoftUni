using System;

namespace BusTickets.Client.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] data)
        {
            Environment.Exit(0);
            return null;
        }
    }
}