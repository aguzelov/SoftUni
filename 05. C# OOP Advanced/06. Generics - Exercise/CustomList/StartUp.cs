using CustomList;

internal class StartUp
{
    private static void Main(string[] args)
    {
        CommandInterpreter interpreter = new CommandInterpreter(new CustomList<string>());

        interpreter.Run();
    }
}