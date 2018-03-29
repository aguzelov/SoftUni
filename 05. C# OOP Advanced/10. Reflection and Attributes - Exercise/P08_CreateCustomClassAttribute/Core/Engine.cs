using P08_CreateCustomClassAttribute.Contracts;
using P08_CreateCustomClassAttribute.Core.Commands;
using System;
using System.Linq;
using System.Reflection;

namespace P08_CreateCustomClassAttribute.Core
{
    public class Engine
    {
        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();
                if(command == "END") break;

                IExecutable exe = ParseCommand(command);
                string result = exe.Execute();

                Console.WriteLine(result);
            }
        }

        private IExecutable ParseCommand(string commandName)
        {
            Type commandType = Assembly.GetExecutingAssembly().GetTypes()
                .First(t => t.Name.Contains(commandName));

            Command command = (Command)Activator.CreateInstance(commandType, new object[] { "StartUp" });

            return command;
        }
    }
}