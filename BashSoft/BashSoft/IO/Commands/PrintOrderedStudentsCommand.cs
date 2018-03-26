using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("order")]
    public class PrintOrderedStudentsCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public PrintOrderedStudentsCommand(string input, string[] data)
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
            string orderBy = this.Data[2].ToLower();
            string command = this.Data[3].ToLower();
            string quantity = this.Data[4].ToLower();

            TryParseParametersForOrderAndTake(command, orderBy, courseName, quantity);
        }

        private void TryParseParametersForOrderAndTake(string command, string orderBy, string courseName, string quantity)
        {
            if (command == "take")
            {
                if (quantity == "all")
                {
                    this.repository.OrderAndTake(courseName, orderBy);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(quantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.repository.OrderAndTake(courseName, orderBy, studentsToTake);
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