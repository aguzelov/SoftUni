using Iterator.Contracts;
using Iterator.Core;

namespace Iterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IInterpreter interpreter = new CommandInterpreter();
            IEngine engine = new Engine(interpreter);
            engine.Run();
        }
    }
}