using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


public class GreedyTimes
{
    private static Dictionary<string, List<Item>> bag = new Dictionary<string, List<Item>>()
    {
        {"Gold", new List<Item>() },
        {"Gem", new List<Item>() },
        {"Cash", new List<Item>() }
    };

    private static decimal allAmount = 0;
    private static decimal goldAmount = 0;
    private static decimal gemAmount = 0;
    private static decimal cashAmount = 0;

    public static void Main()
    {
        decimal bagCapacity = decimal.Parse(Console.ReadLine());

        string[] itemQuantityPairs = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();


        for (int index = 0; index < itemQuantityPairs.Length; index += 2)
        {
            string item = itemQuantityPairs[index];
            decimal quantity = decimal.Parse(itemQuantityPairs[index + 1]);

            if (bagCapacity < allAmount + quantity)
            {
                continue;
            }

            Func<string, bool> gold = g => g.ToLower().Equals("Gold".ToLower());
            Func<string, bool> gem = g => g.ToLower().EndsWith("Gem".ToLower()) && g.Length >= 4;
            Func<string, bool> cash = c =>
            {
                bool allIsLetter = true;
                foreach (var l in c)
                {
                    if (!char.IsLetter(l)) allIsLetter = false;
                }

                return c.Length == 3 && allIsLetter;
            };

            bool hasAddingItem = false;

            if (Validate(item, gold))
            {
                hasAddingItem = AddGold(new Item(item, quantity));
            }
            else if (Validate(item, gem))
            {
                hasAddingItem = AddGem(new Item(item, quantity));
            }
            else if (Validate(item, cash))
            {
                hasAddingItem = AddCash(new Item(item, quantity));
            }

            if (hasAddingItem)
            {
                allAmount += quantity;
            }
        }

        PrintBag();
    }

    private static bool Validate(string item, Func<string, bool> isValid)
    {
        return isValid(item);
    }

    private static void PrintBag()
    {
        foreach (var item in bag.OrderByDescending(x => x.Value.Sum(a => a.Quantity)))
        {
            decimal totalAmount = item.Value.Sum(a => a.Quantity);

            if (totalAmount > 0)
            {
                if (item.Key.ToLower().Equals("Gold".ToLower()))
                {
                    Console.WriteLine($"<Gold> ${totalAmount}");
                    Console.WriteLine($"##Gold - {totalAmount}");
                }
                else
                {
                    Console.WriteLine($"<{item.Key}> ${totalAmount}");
                    foreach (var currentItem in item.Value.OrderByDescending(a => a.Name).ThenBy(a => a.Quantity))
                    {
                        if (currentItem.Quantity == 0) continue;

                        Console.WriteLine($"##{currentItem.Name} - {currentItem.Quantity}");
                    }
                }
            }
        }
    }

    private static bool AddGold(Item item)
    {
        if (!bag["Gold"].Contains(item))
        {
            bag["Gold"].Add(item);
        }
        else
        {
            int index = bag["Gold"].FindIndex(a => a.Name == item.Name);
            if (index < 0)
            {
                bag["Gold"].Add(item);
            }
            else
            {
                bag["Gold"][index].Quantity += item.Quantity;
            }
        }

        return true;
    }

    private static bool AddGem(Item item)
    {
        decimal currentGoldAmount = bag["Gold"].Sum(a => a.Quantity);
        decimal currentGemAmout = bag["Gem"].Sum(a => a.Quantity);

        if (currentGoldAmount < currentGemAmout + item.Quantity)
        {
            return false;
        }

        if (!bag["Gem"].Contains(item))
        {
            bag["Gem"].Add(item);
        }
        else
        {
            int index = bag["Gem"].FindIndex(a => a.Name == item.Name);
            if (index < 0)
            {
                bag["Gem"].Add(item);
            }
            else
            {
                bag["Gem"][index].Quantity += item.Quantity;
            }
        }

        return true;
    }

    private static bool AddCash(Item item)
    {
        decimal currentGemAmount = bag["Gem"].Sum(a => a.Quantity);
        decimal currentCashAmout = bag["Cash"].Sum(a => a.Quantity);

        if (currentGemAmount < currentCashAmout + item.Quantity)
        {
            return false;
        }

        if (!bag["Cash"].Contains(item))
        {
            bag["Cash"].Add(item);
        }
        else
        {
            int index = bag["Cash"].FindIndex(a => a.Name == item.Name);
            if (index < 0)
            {
                bag["Cash"].Add(item);
            }
            else
            {
                bag["Cash"][index].Quantity += item.Quantity;
            }
        }

        return true;
    }
}

public class Item
{
    public string Name { get; set; }
    public decimal Quantity { get; set; }

    public Item(string name, decimal quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    private bool Equals(Item other)
    {
        return this.Name == other.Name;
    }

    public override bool Equals(object obj)
    {
        var other = obj as Item;
        if (other == null) return false;

        return this.Equals(other);
    }

    public override int GetHashCode()
    {
        return this.GetHashCode();
    }
}
