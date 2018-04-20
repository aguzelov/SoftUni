using System.Collections.Generic;

public class InspectCommand : AbstractCommand
{
    public InspectCommand(List<string> args, IManager manager)
        : base(args, manager)
    {
    }

    public override string Execute()
    {
        string result = this.Manager.Inspect(this.ArgsList);
        return result;
    }
}