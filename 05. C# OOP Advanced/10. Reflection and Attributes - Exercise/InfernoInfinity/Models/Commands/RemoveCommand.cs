using P09_InfernoInfinity.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace P09_InfernoInfinity.Models.Commands
{
    public class RemoveCommand : Command
    {
        public RemoveCommand(string[] data) : base(data)
        {
        }

        public override void Execute(List<IWeapon> weapons)
        {
            string weaponName = this.Data[0];
            int socketIndex = int.Parse(this.Data[1]);

            weapons.FirstOrDefault(w => w.Name == weaponName)?.Remove(socketIndex);
        }
    }
}