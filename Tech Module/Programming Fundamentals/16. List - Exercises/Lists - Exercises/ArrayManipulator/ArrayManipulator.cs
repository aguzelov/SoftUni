using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToList();

            while (true)
            {
                List<string> commands = Console.ReadLine()
                                        .Split(' ')
                                        .ToList();

                if (commands[0] == "add")
                {
                    int index = int.Parse(commands[1]);
                    int element = int.Parse(commands[2]);

                    list.Insert(index, element);
                }
                else if (commands[0] == "addMany")
                {
                    int index = int.Parse(commands[1]);

                    commands.RemoveAt(0);
                    commands.RemoveAt(0);
                    List<int> elements = commands.Select(p => int.Parse(p)).ToList();

                    list.InsertRange(index, elements);
                }
                else if (commands[0] == "contains")
                {
                    int element = int.Parse(commands[1]);
                    if (list.Contains(element))
                    {
                        Console.WriteLine(list.IndexOf(element));
                    }
                    else
                    {
                        Console.WriteLine("-1");
                    }
                }
                else if (commands[0] == "remove")
                {
                    int index = int.Parse(commands[1]);
                    list.RemoveAt(index);
                }
                else if (commands[0] == "shift")
                {
                    int pos = int.Parse(commands[1]);
                    for (int i = 0; i < pos; i++)
                    {
                        int firstElem = list[0];
                        list.RemoveAt(0);
                        list.Add(firstElem);
                    }
                }
                else if (commands[0] == "sumPairs")
                {
                    int first;
                    int second;

                    for (int i = 0; i < list.Count - 1; i++)
                    {
                        first = i;
                        second = i + 1;

                        list[first] = list[first] + list[second];
                        list.RemoveAt(second);
                    }
                }
                else if (commands[0] == "print")
                {
                    Console.WriteLine("[" + string.Join(", ", list) + "]");
                    return;
                }
            }
        }
    }
}
