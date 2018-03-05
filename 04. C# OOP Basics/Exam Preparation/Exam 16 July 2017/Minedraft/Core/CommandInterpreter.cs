using System.Linq;

public class CommandInterpreter
{
    private InputReader reader;
    private OutputWriter writer;
    private DraftManager manager;

    public CommandInterpreter()
    {
        this.reader = new InputReader();
        this.writer = new OutputWriter();
        this.manager = new DraftManager();
    }

    public void Start()
    {
        while (true)
        {
            string[] commandArgs = this.reader.ReadLine().Split();
            string command = commandArgs[0];

            string registerResult = string.Empty;

            switch (command)
            {
                case "RegisterHarvester":
                    registerResult = this.manager.RegisterHarvester(commandArgs.Skip(1).ToList());
                    break;

                case "RegisterProvider":
                    registerResult = this.manager.RegisterProvider(commandArgs.Skip(1).ToList());
                    break;

                case "Day":
                    registerResult = this.manager.Day();
                    break;

                case "Mode":
                    registerResult = this.manager.Mode(commandArgs.Skip(1).ToList());
                    break;

                case "Check":
                    registerResult = this.manager.Check(commandArgs.Skip(1).ToList());
                    break;

                case "Shutdown":
                    registerResult = this.manager.ShutDown();
                    break;
            }

            if (registerResult != string.Empty) this.writer.WriteLine(registerResult);

            if (command == "Shutdown") break;
        }
    }
}