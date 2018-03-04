public class Startup
{
    public static void Main()
    {
        var interpreter = new CommandInterpreter(new NationsBuilder());
        interpreter.Execute();
    }
}