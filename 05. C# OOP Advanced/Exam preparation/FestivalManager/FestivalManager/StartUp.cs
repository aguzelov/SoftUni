namespace FestivalManager
{
    using Core;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Entities;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public static class StartUp
    {
        public static void Main(string[] args)
        {
            //IReader reader = new ConsoleReader();
            //IWriter writer = new ConsoleWriter();

            ISetFactory setFactory = new SetFactory();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            IPerformerFactory performerFactory = new PerformerFactory();
            ISongFactory songFactory = new SongFactory();

            IStage stage = new Stage();
            IFestivalController festivalController = new FestivalController(stage, setFactory, instrumentFactory, performerFactory, songFactory);
            ISetController setController = new SetController(stage);

            var engine = new Engine(festivalController, setController);

            engine.Run();
        }
    }
}