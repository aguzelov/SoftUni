using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;

    private double totalEnergyProvided;
    private double totalMinedOre;

    private ModeType mode;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();

        this.mode = ModeType.Full;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        try
        {
            Harvester harvester = HarvesterFactory.Create(arguments);

            harvesters.Add(harvester);

            return $"Successfully registered {type} Harvester - {harvester.Id}";
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            string propertyName = aoore.ParamName;
            return $"Harvester is not registered, because of it's {propertyName}";
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        try
        {
            Provider provider = ProviderFactory.Create(arguments);
            providers.Add(provider);

            return $"Successfully registered {type} Provider - {provider.Id}";
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            string propertyName = aoore.ParamName;
            return $"Provider is not registered, because of it's {propertyName}";
        }
    }

    public string Day()
    {
        double currentEnergyProvided = this.providers.Sum(p => p.EnergyOutput);

        this.totalEnergyProvided += currentEnergyProvided;

        double totalEnergyRequirement = CalculateEnergyRequiredByMode();

        StringBuilder sb = new StringBuilder();

        sb.Append($"A day has passed.{Environment.NewLine}");
        sb.Append($"Energy Provided: {currentEnergyProvided}{Environment.NewLine}");

        if (this.totalEnergyProvided >= totalEnergyRequirement)
        {
            this.totalEnergyProvided -= totalEnergyRequirement;
            double totalOreOutput = CalculateOreOutputByMode();
                
            this.totalMinedOre += totalOreOutput;

            sb.Append($"Plumbus Ore Mined: {totalOreOutput}");
        }
        else
        {
            sb.Append($"Plumbus Ore Mined: 0");
        }

        return sb.ToString();
    }

    private double CalculateOreOutputByMode()
    {
        double OreOutput = this.harvesters.Sum(h => h.OreOutput * (((double)this.mode) / 100));

        return OreOutput;
    }

    private double CalculateEnergyRequiredByMode()
    {
        double energy = 0;
        if (this.mode.ToString() == "Half")
        {
            energy += this.harvesters.Sum(h => h.EnergyRequirement * (((double)this.mode + 10) / 100));
        }
        else
        {
            energy += this.harvesters.Sum(h => h.EnergyRequirement * (((double)this.mode) / 100));
        }

        return energy;
    }

    public string Mode(List<string> arguments)
    {
        string newMode = arguments[0];

        Enum.TryParse(newMode, out this.mode);

        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        if (this.harvesters.Any(h => h.Id == id))
        {
            Harvester harvester = this.harvesters.FirstOrDefault(h => h.Id == id);
            return harvester.ToString();
        }
        else if (this.providers.Any(p => p.Id == id))
        {
            Provider provider = this.providers.FirstOrDefault(p => p.Id == id);
            return provider.ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"System Shutdown{Environment.NewLine}");
        sb.Append($"Total Energy Stored: {this.totalEnergyProvided}{Environment.NewLine}");
        sb.Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString();
    }
}