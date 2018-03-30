using P09_InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P09_InfernoInfinity.Core
{
    public class Engine
    {
        private readonly List<IWeapon> weapons;
        private readonly IReader reader;

        public Engine(IReader reader)
        {
            this.weapons = new List<IWeapon>();

            this.reader = reader;
        }

        public void Run()
        {
            while (true)
            {
                string[] commandArgs = reader.ReadLine().Split(";");
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

            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, parametersData);

            return command;
        }
    }
}