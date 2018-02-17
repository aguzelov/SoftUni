using System;

public class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        PrintRow(n);
    }

    private static void PrintRow(int n)
    {
        if (n == 1)
        {
            Console.WriteLine("*");
        }
        else
        {
            int stars = 0;
            for (int i = 1; i <= n - 1; i++)
            {
                Console.Write(RepeatStr(" ", n - i));
                Console.Write(RepeatStr("* ", stars));
                Console.WriteLine("*");
                stars++;
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(RepeatStr(" ", i));
                Console.Write(RepeatStr("* ", stars));
                Console.WriteLine("*");
                stars--;
            }
        }
    }

    public static String RepeatStr(String str, int count)
    {
        String text = "";
        for (int i = 0; i < count; i++)
        {
            text = text + str;
        }
        return text;
    }
}