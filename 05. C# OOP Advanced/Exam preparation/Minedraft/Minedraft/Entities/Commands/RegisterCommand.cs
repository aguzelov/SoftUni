using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private const string harvesterString = "Harvester";
    private IHarvesterController harvesterController;

    private IProviderController providerController;

    public RegisterCommand(IHarvesterController harvesterController, IProviderController providerController, IList<string> arguments) :
        base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var type = this.Arguments[0];
        var args = this.Arguments.Skip(1).ToList();

        var result = type == harvesterString ? RegisterHarvester(args) : RegisterProvider(args);

        return result;
    }

    private string RegisterProvider(List<string> args)
    {
        string result = this.providerController.Register(args);

        return result;
    }

    private string RegisterHarvester(List<string> args)
    {
        string result = this.harvesterController.Register(args);

        return result;
    }
}