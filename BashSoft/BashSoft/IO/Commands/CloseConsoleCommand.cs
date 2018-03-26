using BashSoft.Attributes;
using System;

namespace BashSoft.IO.Commands
{
    [Alias("exit")]
    public class CloseConsoleCommand : Command
    {
        public CloseConsoleCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}