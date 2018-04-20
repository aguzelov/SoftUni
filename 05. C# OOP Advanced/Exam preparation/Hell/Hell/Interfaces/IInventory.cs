public interface IInventory
{
    long TotalHitPointsBonus { get; }
    long TotalDamageBonus { get; }
    long TotalIntelligenceBonus { get; }
    long TotalAgilityBonus { get; }
    long TotalStrengthBonus { get; }

    void AddRecipeItem(IRecipe recipe);

    void AddCommonItem(IItem item);
}