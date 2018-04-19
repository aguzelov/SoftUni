using System.Collections.Generic;

public class RepairCommand : Command
{
    private IProviderController providerController;

    public RepairCommand(IProviderController providerController, IList<string> arguments)
        : base(arguments)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        double rapairValue = double.Parse(this.Arguments[0]);
        string result = this.providerController.Repair(rapairValue);
        return result;
    }
}