public class Program
{
    public static void Main(string[] args)
    {
        IReader reader = new Reader();
        IWriter writer = new Writer();

        IEnergyRepository energyRepository = new EnergyRepository();
        IHarvesterController harvesterController = new HarvesterController(energyRepository);
        IProviderController providerController = new ProviderController(energyRepository);

        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController, providerController);

        Engine engine = new Engine(commandInterpreter, reader, writer);
        engine.Run();
    }
}