using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Engine
{
    private IGameController gameController;
    private IWriter writer;
    private IReader reader;

    public Engine(IGameController gameController, IWriter writer, IReader reader)
    {
        this.gameController = gameController;
        this.writer = writer;
        this.reader = reader;
    }

    public void Run()
    {
        var input = this.reader.ReadLine();
        var result = new StringBuilder();
        while (!input.Equals(OutputMessages.EndCommand))
        {
            try
            {
                this.gameController.ParseCommand(input);
            }
            catch (ArgumentException arg)
            {
                writer.AppendLine(arg.Message);
            }
            input = this.reader.ReadLine();
        }
        gameController.RequestResult();
        this.writer.WriteLine();
    }
}