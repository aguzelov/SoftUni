using Iterator.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Iterator.Core
{
    public class CommandInterpreter : IInterpreter
    {
        public CommandInterpreter()
        {
        }

        public ICommand ParseCommand(List<string> args)
        {
            string commandName = args[0];
            List<string> commandParameter = args.Skip(1).ToList();

            var commandType = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name.Contains(commandName + "Command"));

            ICommand command = (ICommand)Activator.CreateInstance(commandType, null);

            FieldInfo[] fieldInfos = commandType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            Type parameterType = commandParameter.GetType();

            foreach (var field in fieldInfos)
            {
                if (field.FieldType == parameterType)
                {
                    field.SetValue(command, commandParameter);
                }
            }

            return command;
        }
    }
}