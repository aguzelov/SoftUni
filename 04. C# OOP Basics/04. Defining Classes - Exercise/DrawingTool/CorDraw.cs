using System;

public class CorDraw
{
    private double width;
    private double height;

    public CorDraw(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public void Draw()
    {
        for (int i = 0; i < (int)height; i++)
        {
            Console.Write("|");

            if ((i > 0 && i < height - 1))
            {
                Console.Write(new string(' ', (int)width));
            }
            else
            {
                Console.Write(new string('-', (int)width));
            }

            Console.WriteLine("|");
        }
    }
}
