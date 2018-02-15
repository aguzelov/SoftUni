using System;

public class StartUp
{
    static void Main()
    {
        string shape = Console.ReadLine();
        double width = double.Parse(Console.ReadLine());

        double height = 0;

        switch (shape)
        {
            case "Square":
                height = width;
                break;
            case "Rectangle":
                height = double.Parse(Console.ReadLine());
                break;
        }

        CorDraw corDraw = new CorDraw(width, height);
        corDraw.Draw();
    }
}