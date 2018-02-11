using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Heists
{
    class Heists
    {
        static void ReadArray(out int[] array)
        {
            array = Console.ReadLine()
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray();
        }

        static KeyValuePair<string, int> ReadLoot(string lootInfo)
        {
            string[] lootArray = lootInfo.Split(' ').ToArray();

            return new KeyValuePair<string, int>(lootArray[0], int.Parse(lootArray[1]));
        }

        static int FindGoodies(string loot, string sign)
        {
            int counter = 0;
            for (int i = 0; i < loot.Length; i++)
            {
                if (loot[i].ToString() == sign)
                {
                    counter++;
                }
            }
            return counter;
        }

        static void Main(string[] args)
        {
            // [0] = jewels price    [1] = gold price
            //  % = jewel sign       $ = gold sign
            ReadArray(out int[] prices);


            string lootInfo = Console.ReadLine();
            long totalEarning = 0;
            long totalExpenses = 0;
            while (lootInfo != "Jail Time")
            {
                KeyValuePair<string, int> loot = ReadLoot(lootInfo);

                totalExpenses += loot.Value;

                int foundedJewels = FindGoodies(loot.Key, "%");
                int foundedGold = FindGoodies(loot.Key, "$");
                totalEarning += foundedJewels * prices[0];
                totalEarning += foundedGold * prices[1];

                lootInfo = Console.ReadLine();
            }

            if (totalEarning >= totalExpenses)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {totalEarning - totalExpenses}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: { totalExpenses - totalEarning}.");
            }

        }
    }
}
