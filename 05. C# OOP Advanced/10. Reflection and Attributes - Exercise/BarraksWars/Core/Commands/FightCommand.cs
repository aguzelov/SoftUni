using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class FightCommand : Command
    {
        public FightCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            return "exit";
        }
    }
}