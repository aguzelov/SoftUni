using Employees.App.Core.Commands.Contracts;
using Employees.App.Core.Contracts;
using System;
using System.Linq;

namespace Employees.App.Core
{
    public class Engine
    {
        private readonly ICommandInterpreter interpreter;

        public Engine(ICommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine().Trim();

                string[] commandData = input.Split();
                string commandName = commandData[0];
                string[] commandTokens = commandData.Skip(1).ToArray();

                try
                {
                    ICommand command = interpreter.GetCommand(commandName);
                    command.Execute(commandTokens);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}