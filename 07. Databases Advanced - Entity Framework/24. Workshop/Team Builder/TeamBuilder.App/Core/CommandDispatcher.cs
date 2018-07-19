using System;
using System.Linq;
using System.Reflection;
using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.App.Core.Contracts;

namespace TeamBuilder.App.Core
{
    public class CommandDispatcher : IDispatcher
    {
        private IServiceProvider serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Dispatch(string input)
        {
            string result = string.Empty;

            string[] inputArgs = input.Split();
            string commandName = inputArgs[0];
            string[] commandTokens = inputArgs.Skip(1).ToArray();

            ICommand command = GetCommand(commandName);
            result = command.Execute(commandTokens);

            return result;
        }

        private ICommand GetCommand(string commandName)
        {
            Type commandType = null;
            try
            {
                commandType = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => typeof(ICommand).IsAssignableFrom(t)
                                && t.Name == commandName + "Command")
                    .Single();
            }
            catch (Exception)
            {
                throw new NotSupportedException($"Command {commandName} not valid!");
            }

            var constructor = commandType.GetConstructors().First();
            var parameters = constructor.GetParameters()
                .Select(p => this.serviceProvider.GetService(p.ParameterType))
                .ToArray();

            ICommand command = (ICommand)constructor.Invoke(parameters);

            return command;
        }
    }
}