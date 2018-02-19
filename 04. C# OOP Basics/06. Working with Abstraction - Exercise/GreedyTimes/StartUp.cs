using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        string[] items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var bag = new Dictionary<string, Dictionary<string, long>>();

        long totalGold = 0;
        long totalGem = 0;
        long totalCash = 0;

        for (int i = 0; i < items.Length; i += 2)
        {
            string item = items[i];
            long quantity = long.Parse(items[i + 1]);
            string itemType = GetItemType(item);

            if (itemType == "")
            {
                continue;
            }
            else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
            {
                continue;
            }

            switch (itemType)
            {
                case "Gem":
                    if (!CanAddItem(bag, itemType, "Gold", quantity)) continue;
                    break;
                case "Cash":
                    if (!CanAddItem(bag, itemType, "Gem", quantity)) continue;
                    break;
            }

            AddInBag(bag, item, quantity, itemType);
            IncreaseAmountForCurrentItem(ref totalGold, ref totalGem, ref totalCash, quantity, itemType);
        }

        Print(bag);
    }

    private static void IncreaseAmountForCurrentItem(ref long totalGold, ref long totalGem, ref long totalCash, long quantity, string itemType)
    {
        if (itemType == "Gold")
        {
            totalGold += quantity;
        }
        else if (itemType == "Gem")
        {
            totalGem += quantity;
        }
        else if (itemType == "Cash")
        {
            totalCash += quantity;
        }
    }

    private static void AddInBag(Dictionary<string, Dictionary<string, long>> bag, string item, long quantity, string itemType)
    {
        if (!bag.ContainsKey(itemType))
        {
            bag[itemType] = new Dictionary<string, long>();
        }

        if (!bag[itemType].ContainsKey(item))
        {
            bag[itemType][item] = 0;
        }

        bag[itemType][item] += quantity;
    }

    private static bool CanAddItem(Dictionary<string, Dictionary<string, long>> bag, string itemType, string otherType, long quantity)
    {
        if (!bag.ContainsKey(itemType))
        {
            if (bag.ContainsKey(otherType))
            {
                if (quantity > bag[otherType].Values.Sum())
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (bag[itemType].Values.Sum() + quantity > bag[otherType].Values.Sum())
        {
            return false;
        }

        return true;
    }

    private static string GetItemType(string item)
    {
        string itemType = string.Empty;

        if (item.Length == 3)
        {
            itemType = "Cash";
        }
        else if (item.ToLower().EndsWith("gem"))
        {
            itemType = "Gem";
        }
        else if (item.ToLower() == "gold")
        {
            itemType = "Gold";
        }

        return itemType;
    }

    private static void Print(Dictionary<string, Dictionary<string, long>> bag)
    {
        foreach (var x in bag)
        {
            Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
            foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                Console.WriteLine($"##{item2.Key} - {item2.Value}");
            }
        }
    }
}   