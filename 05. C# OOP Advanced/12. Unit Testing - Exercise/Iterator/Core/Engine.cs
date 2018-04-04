using Iterator.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Iterator.Core
{
    public class Engine : IEngine
    {
        private const string EndCommand = "END";
        private IInterpreter interpreter;
        private ListIterator list;

        public Engine(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != EndCommand)
            {
                string[] tokens = input.Split();

                ICommand command = this.interpreter.ParseCommand(tokens.ToList());
                try
                {
                    command.Execute(ref this.list);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private ICommand ParseCommand(List<string> list)
        {
            string command = list[0];
            string[] constructorArgs = list.Skip(1).ToArray();

            Type listType = typeof(ListIterator);
            ConstructorInfo constructorInfo = listType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];

            this.list = (ListIterator)constructorInfo.Invoke(new object[] { constructorArgs });

            return null;
        }
    }
}