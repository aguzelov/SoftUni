using System;

public class LastArmyMain
{
    public static void Main()
    {
        IWriter writer = new ConsoleWriter();
        IReader reader = new ConsoleReader();
        IArmy army = new Army();
        IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        IWareHouse wareHouse = new WareHouse(ammunitionFactory);
        ISoldierFactory soldierFactory = new SoldierFactory();
        IMissionFactory missionFactory = new MissionFactory();
        MissionController missionController = new MissionController(army, wareHouse);

        IGameController gameController = new GameController(army, wareHouse, soldierFactory, missionFactory, missionController, writer);

        Engine engine = new Engine(gameController, writer, reader);
        engine.Run();
    }
}