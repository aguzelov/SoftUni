using System;

namespace BashSoft
{
    public class Greeting
    {
        public static void Message()
        {
            string message = $"Hello {Environment.UserName}!";

            int leftOffSet = (Console.WindowWidth / 2) - 10;
            int topOffSet = (Console.WindowHeight / 2);
            Console.SetCursorPosition(leftOffSet, topOffSet);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(message);

            Console.ResetColor();

            System.Threading.Thread.Sleep(1500);
            Console.Clear();
        }
    }
}