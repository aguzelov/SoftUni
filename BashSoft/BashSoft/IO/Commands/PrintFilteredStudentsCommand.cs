using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("filter")]
    public class PrintFilteredStudentsCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public PrintFilteredStudentsCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 5)
            {
                throw new InvalidCommandException(this.Input);
            }

            string courseName = this.Data[1];
            string filter = this.Data[2].ToLower();
            string command = this.Data[3].ToLower();
            string quantity = this.Data[4].ToLower();

            TryParseParametersFromFilterAndTake(command, quantity, courseName, filter);
        }

        private void TryParseParametersFromFilterAndTake(string command, string quantity, string courseName, string filter)
        {
            if (command == "take")
            {
                if (quantity == "all")
                {
                    this.repository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(quantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.repository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        throw new InvalidTakeQueryParamterException();
                    }
                }
            }
            else
            {
                throw new InvalidCommandException(command);
            }
        }
    }
}