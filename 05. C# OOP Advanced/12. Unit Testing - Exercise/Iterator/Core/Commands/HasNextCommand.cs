using Iterator.Contracts;
using System;

namespace Iterator.Core.Commands
{
    public class HasNextCommand : ICommand
    {
        public HasNextCommand()
        {
        }

        public void Execute(ref ListIterator list)
        {
            string result = list.HasNext().ToString();

            Console.WriteLine(result);
        }
    }
}