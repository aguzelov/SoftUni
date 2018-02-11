using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

public class CubicArtillery
{
    private static int bunkerMaximumCapacity;

    private static StringBuilder result = new StringBuilder();

    public static void Main()
    {
        bunkerMaximumCapacity = int.Parse(Console.ReadLine());
        Queue<Bunker> bunkers = new Queue<Bunker>();

        var input = Console.ReadLine();

        while (input != "Bunker Revision")
        {
            string[] line = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            ReadLine(line, ref bunkers);

            input = Console.ReadLine();
        }

        Console.WriteLine(result);
    }

    private static void ReadLine(string[] line, ref Queue<Bunker> bunkers)
    {
        for (int i = 0; i < line.Length; i++)
        {
            bool hasParsed = int.TryParse(line[i], out int weapon);
            if (hasParsed)
            {
                if (bunkers.Count == 1 && weapon <= bunkerMaximumCapacity)
                {
                    bunkers.Peek().CurrentUsedSpace += weapon;
                    bunkers.Peek().Weapons.Enqueue(weapon);

                    while (bunkers.Peek().CurrentUsedSpace > bunkerMaximumCapacity)
                    {
                        bunkers.Peek().CurrentUsedSpace -= bunkers.Peek().Weapons.Dequeue();
                    }
                }
                else
                {
                    while (bunkers.Count > 1)
                    {
                        if (bunkers.Peek().CurrentUsedSpace + weapon <= bunkerMaximumCapacity)
                        {
                            bunkers.Peek().CurrentUsedSpace += weapon;
                            bunkers.Peek().Weapons.Enqueue(weapon);
                            break;
                        }
                        else
                        {
                            Remove(bunkers.Dequeue());
                        }
                    }
                }

                if (bunkers.Count > 1 && bunkers.Peek().CurrentUsedSpace == bunkerMaximumCapacity)
                {
                    Remove(bunkers.Dequeue());
                }
            }
            else
            {
                bunkers.Enqueue(new Bunker
                {
                    Name = line[i],
                    CurrentUsedSpace = 0,
                    Weapons = new Queue<int>()
                });
            }
        }
    }

    private static void Remove(Bunker bunker)
    {
        if (bunker.CurrentUsedSpace == 0)
        {
            result.Append($"{bunker.Name} -> Empty");
        }
        else
        {
            result.Append($"{bunker.Name} -> {string.Join(", ", bunker.Weapons)}");
        }

        result.Append(Environment.NewLine);
    }
}

public class Bunker
{
    public string Name { get; set; }
    public Queue<int> Weapons { get; set; }
    public int CurrentUsedSpace { get; set; }
}
