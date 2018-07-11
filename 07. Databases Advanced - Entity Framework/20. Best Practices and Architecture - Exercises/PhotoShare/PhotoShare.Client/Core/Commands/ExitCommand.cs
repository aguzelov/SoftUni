namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using System;

    public class ExitCommand : ICommand
    {
        public string Execute(params string[] data)
        {
            Console.WriteLine("Bye-bye!");
            Environment.Exit(0);
            return null;
        }
    }
}