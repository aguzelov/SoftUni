using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("readDb")]
    public class ReadDatabaseCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public ReadDatabaseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }
            string fileName = this.Data[1];
            this.repository.LoadData(fileName);
        }
    }
}