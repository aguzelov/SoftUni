using System;
using System.Collections.Generic;

public class HarvesterController : IHarvesterController
{
    private const int percentConstant = 100;
    private List<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory factory;
    private WorkingMode mode;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();

        this.mode = WorkingMode.Full;
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string Register(IList<string> arguments)
    {
        Type factoryType = typeof(HarvesterFactory);
        this.factory = (IHarvesterFactory)Activator.CreateInstance(factoryType, null);

        var harvester = this.factory.GenerateHarvester(arguments);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }

    public string Produce()
    {
        double neededEnergy = 0;

        foreach (var harvester in this.harvesters)
        {
            neededEnergy += harvester.EnergyRequirement * ((double)this.mode) / percentConstant;
        }

        double minedOres = 0;
        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.Produce() * ((double)this.mode) / percentConstant;
            }
        }

        this.OreProduced += minedOres;

        return string.Format(Constants.OreOutputToday, minedOres);
    }

    public string ChangeMode(string mode)
    {
        this.mode = (WorkingMode)Enum.Parse(typeof(WorkingMode), mode);

        List<IHarvester> reminder = new List<IHarvester>();
        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var harvester in reminder)
        {
            this.harvesters.Remove(harvester);
        }

        return string.Format(Constants.ChangeMode, mode);
    }
}