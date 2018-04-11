public class Program
{
    public static void Main(string[] args)
    {
        Logger combatLog = new CombatLogger();
        Logger eventLog = new EventLogger();

        combatLog.SetSuccessor(eventLog);

        IAttackGroup group = new Group();
        group.AddMember(new Warrior("Quannarin", 10, combatLog));
        group.AddMember(new Warrior("Pancho", 15, combatLog));

        ITarget dragon = new Dragon("Mincho", 200, 25);

        IExecutor executor = new CommandExecutor();
        ICommand groupTarget = new GroupTargetCommand(group, dragon);
        ICommand attack = new GroupAttackCommand(group);
    }
}