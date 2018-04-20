using System.Collections.Generic;

public class RecipeItem : AbstractItem, IRecipe
{
    public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, IList<string> commonItemsNames)
        : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {
        this.RequiredItems = new List<string>(commonItemsNames);
    }

    public IList<string> RequiredItems { get; }
}