using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    private IHarvesterController harvesterController;

    private IProviderController providerController;

    public ShutdownCommand(IHarvesterController harvesterController, IProviderController providerController, IList<string> arguments)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var sb = new StringBuilder();

        sb.AppendLine(Constants.SystemShutdown);

        sb.AppendLine(string.Format(Constants.TotalEnergyProduced, this.providerController.TotalEnergyProduced));

        sb.Append(string.Format(Constants.TotalMinedPlumbusOre, this.harvesterController.OreProduced));

        return sb.ToString().Trim();
    }
}