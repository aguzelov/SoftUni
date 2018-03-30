using P09_InfernoInfinity.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P09_InfernoInfinity.Models.Commands
{
    public class PrintCommand : Command
    {
        public PrintCommand(string[] data) : base(data)
        {
        }

        public override void Execute(List<Weapon> weapons)
        {
            string weaponName = this.Data[0];

            Weapon weapon = weapons.FirstOrDefault(w => w.Name == weaponName);
            if (weapon != null)
            {
                Console.WriteLine(weapon);
            }
        }
    }
}