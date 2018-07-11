namespace PhotoShare.Client.Core
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Client.Validation;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string DispatchCommand(string[] commandParameters)
        {
            string commandName = commandParameters[0];
            string[] commandTokens = commandParameters.Skip(1).ToArray();

            ICommand command = null;
            string result = null;
            try
            {
                command = GetCommand(commandName);

                result = command.Execute(commandTokens);
            }
            catch (Exception e)
            {
                if (e is NullReferenceException || e is IndexOutOfRangeException)
                {
                    throw new InvalidOperationException($"Command {commandName} not valid!");
                }

                throw e;
            }

            return result;
        }

        private ICommand GetCommand(string commandName)
        {
            Type commandType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ICommand).IsAssignableFrom(t) && t.Name == commandName + "Command")
                .FirstOrDefault();

            commandType.GetCustomAttribute<CredentialAttribute>();

            var constructor = commandType.GetConstructors().FirstOrDefault();
            var parameters = constructor.GetParameters()
                .Select(p => serviceProvider.GetService(p.ParameterType))
                .ToArray();

            var command = (ICommand)constructor.Invoke(parameters);

            return command;
        }
    }
}