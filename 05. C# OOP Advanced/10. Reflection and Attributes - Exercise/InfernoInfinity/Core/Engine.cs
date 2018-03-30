using P09_InfernoInfinity.Contracts;
using P09_InfernoInfinity.Models.Commands;
using P09_InfernoInfinity.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P09_InfernoInfinity.Core
{
    public class Engine
    {
        private List<Weapon> weapons;

        public Engine()
        {
            this.weapons = new List<Weapon>();
        }

        public void Run()
        {
            while (true)
            {
                string[] commandArgs = Console.ReadLine().Split(";");
                string command = commandArgs[0];

                IExecutable exe = ParseCommand(command, commandArgs.Skip(1).ToArray());
                exe.Execute(this.weapons);
            }
        }

        private IExecutable ParseCommand(string commandName, string[] commandArgs)
        {
            object[] parametersData = {
                commandArgs
            };

            Type commandType = Assembly.GetExecutingAssembly().GetTypes()
                .First(t => t.Name.ToLower().Contains(commandName.ToLower()));

            Command command = (Command)Activator.CreateInstance(commandType, parametersData);

            return command;
        }
    }
}