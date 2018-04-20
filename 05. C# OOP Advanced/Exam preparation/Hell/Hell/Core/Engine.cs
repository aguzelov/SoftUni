using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Engine
{
    private IInputReader reader;
    private IOutputWriter writer;
    private IManager heroManager;

    public Engine(IInputReader reader, IOutputWriter writer, IManager heroManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();
            List<string> arguments = this.parseInput(inputLine);

            this.writer.WriteLine(this.processInput(arguments));

            isRunning = !this.ShouldEnd(inputLine);
        }
    }

    private List<string> parseInput(string input)
    {
        return input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string processInput(List<string> arguments)
    {
        string command = arguments[0];
        arguments.RemoveAt(0);

        Type commandType = Type.GetType(command + "Command");

        ConstructorInfo constuctor = commandType.GetConstructors().First();
        ParameterInfo[] parameterInfos = constuctor.GetParameters();
        object[] ctorArgs = new object[]
        {
            arguments,
            this.heroManager
        };

        ICommand cmd = (ICommand)constuctor.Invoke(ctorArgs);
        return cmd.Execute();
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}