using System.Collections.Generic;

public class ModeCommand : Command
{
    private IHarvesterController harvesterController;

    public ModeCommand(IHarvesterController harvesterController, IList<string> arguments)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        var mode = this.Arguments[0];
        string result = this.harvesterController.ChangeMode(mode);

        return result;
    }
}