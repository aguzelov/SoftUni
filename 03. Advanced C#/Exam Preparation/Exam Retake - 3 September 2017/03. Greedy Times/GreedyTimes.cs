using System;
using System.Collections.Generic;
using System.Linq;

public class GreedyTimes
{
    private static readonly Dictionary<string, decimal> goldBag = new Dictionary<string, decimal>();
    private static readonly Dictionary<string, decimal> gemBag = new Dictionary<string, decimal>();
    private static readonly Dictionary<string, decimal> cashBag = new Dictionary<string, decimal>();

    private static decimal allAmount;
    private static decimal goldAmount;
    private static decimal gemAmount;
    private static decimal cashAmount;

    public static void Main()
    {
        var bagCapacity = decimal.Parse(Console.ReadLine());

        var itemQuantityPairs = Console.ReadLine()
            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();


        for (var index = 0; index < itemQuantityPairs.Length; index += 2)
        {
            var item = itemQuantityPairs[index];
            var quantity = decimal.Parse(itemQuantityPairs[index + 1]);

            if (bagCapacity < allAmount + quantity) continue;

            Func<string, bool> gold = g => g.ToLower().Equals("Gold".ToLower());
            Func<string, bool> gem = g => g.ToLower().EndsWith("Gem".ToLower()) && g.Length >= 4;
            Func<string, bool> cash = c =>
            {
                var allIsLetter = true;
                foreach (var l in c)
                    if (!char.IsLetter(l))
                        allIsLetter = false;

                return c.Length == 3 && allIsLetter;
            };

            var hasAddingItem = false;

            if (Validate(item, gold))
            {
                hasAddingItem = AddGold(new Item(item, quantity));
                if (hasAddingItem) goldAmount += quantity;
            }
            else if (Validate(item, gem))
            {
                hasAddingItem = AddGem(new Item(item, quantity));
                if (hasAddingItem) gemAmount += quantity;
            }
            else if (Validate(item, cash))
            {
                hasAddingItem = AddCash(new Item(item, quantity));
                if (hasAddingItem) cashAmount += quantity;
            }

            if (hasAddingItem) allAmount += quantity;
        }

        Print();
    }

    private static bool Validate(string item, Func<string, bool> isValid)
    {
        return isValid(item);
    }

    private static void Print()
    {
        if (goldBag.Any())
        {
            PrintBag(goldBag, "Gold", goldAmount);
            if (gemBag.Any())
            {
                PrintBag(gemBag, "Gem", gemAmount);
                if (cashBag.Any()) PrintBag(cashBag, "Cash", cashAmount);
            }
        }
    }

    private static void PrintBag(Dictionary<string, decimal> bag, string type, decimal amount)
    {
        Console.WriteLine($"<{type}> ${amount}");
        foreach (var item in bag.OrderByDescending(k => k.Key).ThenBy(v => v.Value))
            Console.WriteLine($"##{item.Key} - {item.Value}");
    }

    private static bool AddGold(Item item)
    {
        if (!goldBag.ContainsKey(item.Name)) goldBag.Add(item.Name, 0);

        goldBag[item.Name] += item.Quantity;

        return true;
    }

    private static bool AddGem(Item item)
    {
        if (goldAmount < gemAmount + item.Quantity) return false;

        if (!gemBag.ContainsKey(item.Name)) gemBag.Add(item.Name, 0);

        gemBag[item.Name] += item.Quantity;

        return true;
    }

    private static bool AddCash(Item item)
    {
        if (gemAmount < cashAmount + item.Quantity) return false;

        if (!cashBag.ContainsKey(item.Name)) cashBag.Add(item.Name, 0);

        cashBag[item.Name] += item.Quantity;

        return true;
    }
}

public class Item
{
    public Item(string name, decimal quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    public string Name { get; set; }
    public decimal Quantity { get; set; }

    private bool Equals(Item other)
    {
        return Name == other.Name;
    }

    public override bool Equals(object obj)
    {
        var other = obj as Item;
        if (other == null) return false;

        return Equals(other);
    }

    public override int GetHashCode()
    {
        return GetHashCode();
    }

    public override string ToString()
    {
        return $"##{Name} - {Quantity}";
    }
}