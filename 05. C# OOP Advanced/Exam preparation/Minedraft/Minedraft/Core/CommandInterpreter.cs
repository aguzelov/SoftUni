using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public string ProcessCommand(IList<string> args)
    {
        ICommand command = this.ParseCommand(args);
        string result = command.Execute();

        return result;
    }

    private ICommand ParseCommand(IList<string> args)
    {
        var commandName = args[0];
        var data = args.Skip(1).ToList();

        Type commandType = Assembly.GetExecutingAssembly()
            .GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");

        ParameterInfo[] ctorParams = commandType.GetConstructors().First().GetParameters();
        object[] ctorArgs = new object[ctorParams.Length];

        for (int i = 0; i < ctorArgs.Length; i++)
        {
            if (ctorParams[i].GetType() == this.harvesterController.GetType())
            {
                ctorArgs[i] = this.harvesterController;
            }
            else if (ctorParams[i].GetType() == this.providerController.GetType())
            {
                ctorArgs[i] = this.providerController;
            }
            else
            {
                ctorArgs[i] = data;
            }
        }

        ICommand command = (ICommand)Activator.CreateInstance(commandType, ctorArgs);

        return command;
    }
}