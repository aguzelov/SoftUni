using Iterator.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Iterator.Core.Commands
{
    public class CreateCommand : ICommand
    {
        private List<string> args;

        public CreateCommand()
        {
        }

        public void Execute(ref ListIterator list)
        {
            string[] constructorArgs = args.ToArray();

            Type listType = typeof(ListIterator);
            ConstructorInfo constructorInfo = listType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];

            list = (ListIterator)constructorInfo.Invoke(new object[] { constructorArgs });
        }
    }
}