public class CombatLogger : Logger
{
    public override void Handle(LogType logType, string message)
    {
        switch (logType)
        {
            case LogType.ATTACK:
                System.Console.WriteLine(logType.ToString() + ": " + message);
                break;

            case LogType.MAGIC:
                System.Console.WriteLine(logType.ToString() + ": " + message);
                break;
        }

        this.PassToSuccessor(logType, message);
    }
}