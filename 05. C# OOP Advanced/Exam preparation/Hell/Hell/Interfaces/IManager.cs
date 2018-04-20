using System.Collections.Generic;

public interface IManager
{
    string AddHero(List<string> arguments);

    string AddItemToHero(List<string> arguments);

    string AddRecipeToHero(List<string> arguments);

    string Inspect(List<string> arguments);

    string GenerateResult();
}