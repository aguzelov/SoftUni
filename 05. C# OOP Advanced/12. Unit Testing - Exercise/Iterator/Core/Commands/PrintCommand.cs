using Iterator.Contracts;
using System;

namespace Iterator.Core.Commands
{
    public class PrintCommand : ICommand
    {
        public PrintCommand()
        {
        }

        public void Execute(ref ListIterator list)
        {
            string result = list.Print();

            Console.WriteLine(result);
        }
    }
}