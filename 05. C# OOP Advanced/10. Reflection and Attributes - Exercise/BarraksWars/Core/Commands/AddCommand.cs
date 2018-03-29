using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Attributes;

namespace _03BarracksFactory.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private readonly IRepository repository;
        [Inject]
        private readonly IUnitFactory unitFactory;

        public AddCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = base.Data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}