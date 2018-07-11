using BusTickets.Client.Core.Commands;
using System;
using System.Linq;
using System.Reflection;

namespace BusTickets.Client.Core
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string DispatchCommand(string[] commandParameters)
        {
            string commandName = commandParameters[0].Replace("-", "");
            string[] commandTokens = commandParameters.Skip(1).ToArray();

            string result = string.Empty;
            try
            {
                ICommand command = GetCommand(commandName);
                result = command.Execute(commandTokens);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        private ICommand GetCommand(string commandName)
        {
            Type commandType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ICommand).IsAssignableFrom(t) && t.Name.ToLower() == (commandName + "Command").ToLower())
                .FirstOrDefault();

            var constructor = commandType.GetConstructors().First();
            var parameters = constructor.GetParameters()
                .Select(p => serviceProvider.GetService(p.ParameterType))
                .ToArray();

            ICommand command = (ICommand)constructor.Invoke(parameters);

            return command;
        }
    }
}