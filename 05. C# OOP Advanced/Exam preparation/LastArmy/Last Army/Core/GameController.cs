using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class GameController : IGameController
{
    private const string ResultOutput = "Results:";
    private const string SoldiersOutput = "Soldiers:";
    private const string RegenerationCommand = "Regenerate";
    private const string CommandPrefix = "Parse";
    private const string CommandSuffix = "Command";
    private StringBuilder sb;

    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionControllerField;

    private ISoldierFactory soldierFactory;

    private IMissionFactory missionFactory;

    private IWriter writer;

    public GameController(IArmy army, IWareHouse wareHouse, ISoldierFactory soldierFactory, IMissionFactory missionFactory, MissionController missionController, IWriter writer)
    {
        this.Army = army;
        this.WareHouse = wareHouse;
        this.missionControllerField = missionController;
        this.soldierFactory = soldierFactory;
        this.missionFactory = missionFactory;
        this.writer = writer;

        this.sb = new StringBuilder();
    }

    public IArmy Army
    {
        get { return army; }
        set { army = value; }
    }

    public IWareHouse WareHouse
    {
        get { return wareHouse; }
        set { wareHouse = value; }
    }

    public void ParseCommand(string input)
    {
        var data = input.Split().ToList();
        string commandName = data[0];
        data.RemoveAt(0);

        string commandFullName = CommandPrefix + commandName + CommandSuffix;

        try
        {
            this.GetType()
                .GetMethod(commandFullName, BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(this, new object[] { data });
        }
        catch (TargetInvocationException tie)
        {
            throw tie.InnerException;
        }
    }

    private void ParseSoldierCommand(IList<string> data)
    {
        if (data[0] == RegenerationCommand)
        {
            string soldierType = data[1];
            this.Army.RegenerateTeam(soldierType);
        }
        else
        {
            this.AddSoldier(data);
        }
    }

    private void AddSoldier(IList<string> data)
    {
        string type = data[0];
        string name = data[1];
        int age = int.Parse(data[2]);
        int experience = int.Parse(data[3]);
        double endurance = double.Parse(data[4]);

        ISoldier soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);

        if (!this.wareHouse.TryEquipSoldier(soldier))
        {
            throw new ArgumentException(string.Format(OutputMessages.MissingAmmunitionWhenCreateSoldierError, type, name));
        }
        this.Army.AddSoldier(soldier);
    }

    private void ParseWareHouseCommand(IList<string> data)
    {
        string name = data[0];
        int quantity = int.Parse(data[1]);

        this.WareHouse.AddAmmunition(name, quantity);
    }

    private void ParseMissionCommand(IList<string> data)
    {
        string missionLevel = data[0];
        double scoreToComplete = double.Parse(data[1]);

        IMission mission = this.missionFactory.CreateMission(missionLevel, scoreToComplete);
        this.writer.AppendLine(this.missionControllerField.PerformMission(mission));
    }

    public void RequestResult()
    {
        List<ISoldier> orderedArmy = this.Army.Soldiers.OrderByDescending(s => s.OverallSkill).ToList();
        this.missionControllerField.FailMissionsOnHold();

        this.writer.AppendLine(ResultOutput);
        this.writer.AppendLine(string.Format(OutputMessages.MissionsSummurySuccessful, this.missionControllerField.SuccessMissionCounter));

        this.writer.AppendLine(string.Format(OutputMessages.MissionsSummuryFailed, this.missionControllerField.FailedMissionCounter));
        this.writer.AppendLine(SoldiersOutput);
        this.writer.AppendLine(string.Join(Environment.NewLine, orderedArmy));
    }
}