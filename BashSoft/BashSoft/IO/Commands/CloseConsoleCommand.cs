using System;

namespace BashSoft.IO.Commands
{
    internal class CloseConsoleCommand : Command
    {
        public CloseConsoleCommand(string input, string[] data, Tester judge, StudentsRepository repository,
            IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}