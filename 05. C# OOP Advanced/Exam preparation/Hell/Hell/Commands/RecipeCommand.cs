using System.Collections.Generic;

public class RecipeCommand : AbstractCommand
{
    public RecipeCommand(List<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.AddRecipeToHero(this.ArgsList);
    }
}