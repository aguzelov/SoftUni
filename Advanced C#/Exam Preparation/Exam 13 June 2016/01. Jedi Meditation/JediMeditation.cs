using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class JediMeditation
{
   public static Dictionary<string, List<string>> jedis = new Dictionary<string, List<string>>()
    {
        {"m", new List<string>() },
        {"k", new List<string>() },
        {"p", new List<string>() },
        {"ts", new List<string>() }
    };

    public static bool hasYodaArrive = false;

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var element in input)
            {
                string title = element.First().ToString();

                if (title == "t" || title == "s")
                {
                    jedis["ts"].Add(element);
                }
                else if (title == "y")
                {
                    hasYodaArrive = true;
                }
                else
                {
                    jedis[title].Add(element);
                }
            }
        }

        Print();
    }

    private static void Print()
    {
        if (hasYodaArrive)
        {
            Console.Write(string.Join(" ", jedis["m"]));
            Console.Write(" ");
            Console.Write(string.Join(" ", jedis["k"]));
            Console.Write(" ");
            Console.Write(string.Join(" ", jedis["ts"]));
            Console.Write(" ");
            Console.Write(string.Join(" ", jedis["p"]));
        }
        else
        {
            Console.Write(string.Join(" ", jedis["ts"]));
            Console.Write(" ");
            Console.Write(string.Join(" ", jedis["m"]));
            Console.Write(" ");
            Console.Write(string.Join(" ", jedis["k"]));
            Console.Write(" ");
            Console.Write(string.Join(" ", jedis["p"]));
        }
    }
}
