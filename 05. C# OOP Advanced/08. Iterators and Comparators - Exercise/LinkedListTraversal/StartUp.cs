using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        int numberOfCommands = int.Parse(Console.ReadLine());

        LinkedList<string> linkedList = new LinkedList<string>();
        while (numberOfCommands-- != 0)
        {
            string[] tokens = Console.ReadLine().Split();
            string command = tokens[0];

            switch (command)
            {
                case "Add":
                    string element = tokens[1];
                    linkedList.AddAtLast(element);
                    break;

                case "Remove":
                    element = tokens[1];
                    linkedList.RemoveFromStart(element);
                    break;
            }
        }

        Console.WriteLine(linkedList.Count);
        Console.WriteLine(string.Join(" ", linkedList));
    }
}