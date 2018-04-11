using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        Dispatcher dispatcher = new Dispatcher();
        Handler handler = new Handler();

        dispatcher.NameChange += handler.OnDispatcherNameChange;

        while (true)
        {
            string name = Console.ReadLine();
            if (name == "End") break;

            dispatcher.Name = name;
        }
    }
}