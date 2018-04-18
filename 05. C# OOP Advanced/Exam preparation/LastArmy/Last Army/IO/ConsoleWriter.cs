using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder output;

    public ConsoleWriter()
    {
        this.output = new StringBuilder();
    }

    public void WriteLine()
    {
        Console.WriteLine(this.output.ToString().Trim());
    }

    public void WriteLine(string line)
    {
        Console.WriteLine(this.output.ToString().Trim() + line);
    }

    public void AppendLine(string line)
    {
        this.output.AppendLine(line.Trim());
    }
}