using System;
using System.Linq;

public class CommandInterpreter
{
    private ListyIterator<string> listyIterator;

    public void Run()
    {
        while (true)
        {
            string[] inputArgs = Console.ReadLine().Split();
            string command = inputArgs[0];

            string result = string.Empty;
            switch (command)
            {
                case "Create":
                    this.listyIterator = new ListyIterator<string>(inputArgs.Skip(1).ToArray());
                    break;

                case "Move":
                    result = this.listyIterator.Move().ToString();
                    break;

                case "HasNext":
                    result = this.listyIterator.HasNext().ToString();
                    break;

                case "Print":
                    try
                    {
                        result = this.listyIterator.Print();
                    }
                    catch (InvalidOperationException ioe)
                    {
                        result = ioe.Message;
                    }

                    break;

                case "PrintAll":
                    result = string.Join(" ", this.listyIterator);
                    break;

                case "END":
                    return;
            }

            if (result != string.Empty)
                Console.WriteLine(result);
        }
    }
}