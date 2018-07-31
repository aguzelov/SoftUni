using ProductShop.App.Commands.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace ProductShop.App
{
    public class Engine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            //ExecuteCommand("InitDatabase");
            //ExecuteCommand("ImportJson");
            ExecuteCommand("ExportJson");
        }

        private void ExecuteCommand(string commandName)
        {
            Type commandType = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(ICommand).IsAssignableFrom(t) && t.Name == commandName + "Command")
                .FirstOrDefault();

            var constructor = commandType.GetConstructors().First();
            var parameters = constructor.GetParameters()
                .Select(p => serviceProvider.GetService(p.ParameterType))
                .ToArray();

            ICommand command = (ICommand)constructor.Invoke(parameters);

            command.Execute();
        }
    }
}