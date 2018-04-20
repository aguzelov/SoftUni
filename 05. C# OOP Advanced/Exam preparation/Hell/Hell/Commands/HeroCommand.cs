using System.Collections.Generic;

public class HeroCommand : AbstractCommand
{
    public HeroCommand(List<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        string result = this.Manager.AddHero(this.ArgsList);

        return result;
    }
}