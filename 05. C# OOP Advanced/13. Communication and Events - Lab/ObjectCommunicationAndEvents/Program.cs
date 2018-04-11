public class Program
{
    public static void Main(string[] args)
    {
        Logger combatLog = new CombatLogger();
        Logger eventLog = new EventLogger();

        combatLog.SetSuccessor(eventLog);

        var warrior = new Warrior("Quannarin", 10, combatLog);
        var dragon = new Dragon("Mincho", 100, 25, combatLog);

        IExecutor executor = new CommandExecutor();
        ICommand command = new TargetCommand(warrior, dragon);
        ICommand attack = new AttackCommand(warrior);
    }
}