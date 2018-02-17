using System;

class StartUp
{
    static void Main()
    {
        StudentSystem studentSystem = new StudentSystem();

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "Exit")
        {
            studentSystem.ParseCommand(command);
        }
    }
}