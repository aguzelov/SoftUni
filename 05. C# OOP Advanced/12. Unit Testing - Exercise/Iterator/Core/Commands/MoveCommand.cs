using Iterator.Contracts;
using System;

namespace Iterator.Core.Commands
{
    public class MoveCommand : ICommand
    {
        public MoveCommand()
        {
        }

        public void Execute(ref ListIterator list)
        {
            string result = list.Move().ToString();

            Console.WriteLine(result);
        }
    }
}