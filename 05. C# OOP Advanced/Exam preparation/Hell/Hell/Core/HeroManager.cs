using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IManager
{
    public Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(List<string> arguments)
    {
        string result = null;

        string heroName = arguments[0];
        string heroTypeName = arguments[1];

        try
        {
            Type heroType = Type.GetType(heroTypeName);
            var constructors = heroType.GetConstructors();
            IHero hero = (IHero)constructors[0].Invoke(new object[] { heroName });

            this.heroes.Add(heroName, hero);

            result = string.Format(Constants.HeroCreateMessage, heroTypeName, heroName);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItemToHero(List<string> arguments)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        long strengthBonus = long.Parse(arguments[2]);
        long agilityBonus = long.Parse(arguments[3]);
        long intelligenceBonus = long.Parse(arguments[4]);
        long hitPointsBonus = long.Parse(arguments[5]);
        long damageBonus = long.Parse(arguments[6]);

        IItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
        damageBonus);

        this.heroes[heroName].AddItem(newItem);

        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);

        return result;
    }

    public string AddRecipeToHero(List<string> arguments)
    {
        string result = null;

        string recipeName = arguments[0];
        string heroName = arguments[1];
        long strengthBonus = long.Parse(arguments[2]);
        long agilityBonus = long.Parse(arguments[3]);
        long intelligenceBonus = long.Parse(arguments[4]);
        long hitPointsBonus = long.Parse(arguments[5]);
        long damageBonus = long.Parse(arguments[6]);

        List<string> requiredItems = arguments.Skip(7).ToList();

        IRecipe newRecipe = new RecipeItem(recipeName,
            strengthBonus,
            agilityBonus,
            intelligenceBonus,
            hitPointsBonus,
            damageBonus,
            requiredItems);

        this.heroes[heroName].AddRecipe(newRecipe);

        result = string.Format(Constants.RecipeCreatedMessage, newRecipe.Name, heroName);

        return result;
    }

    public string Inspect(List<String> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    public string GenerateResult()
    {
        List<IHero> orderedHeros = this.heroes
            .Values
            .OrderByDescending(h => h.PrimaryStats)
            .ThenByDescending(h => h.SecondaryStats)
            .ToList();

        StringBuilder sb = new StringBuilder();

        int counter = 1;

        foreach (var hero in orderedHeros)
        {
            sb.AppendLine($"{counter++}. {hero.GetType().Name}: { hero.Name}");
            sb.AppendLine($"###HitPoints: {hero.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Damage}");
            sb.AppendLine($"###Strength: {hero.Strength}");
            sb.AppendLine($"###Agility: {hero.Agility}");
            sb.AppendLine($"###Intelligence: {hero.Intelligence}");

            if (hero.Items.Count == 0)
            {
                sb.AppendLine($"###Items: None");
            }
            else
            {
                sb.Append($"###Items: ");
                var itemsName = hero.Items.Select(i => i.Name).ToList();
                sb.AppendLine(string.Join(", ", itemsName));
            }
        }

        return sb.ToString().Trim();
    }
}