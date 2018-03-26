using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("cdRel")]
    public class ChangeRelativePathCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeRelativePathCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }
            string relPath = this.Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
        }
    }
}