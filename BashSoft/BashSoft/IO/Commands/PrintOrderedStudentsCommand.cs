using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    internal class PrintOrderedStudentsCommand : Command
    {
        public PrintOrderedStudentsCommand(string input, string[] data, Tester judge, StudentsRepository repository,
            IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
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
                    this.Repository.OrderAndTake(courseName, orderBy);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(quantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.Repository.OrderAndTake(courseName, orderBy, studentsToTake);
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