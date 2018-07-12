using Employees.App.Core.Commands.Contracts;
using Employees.App.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace Employees.App.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand GetCommand(string commandName)
        {
            Type commandType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ICommand).IsAssignableFrom(t) && t.Name == commandName + "Command")
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