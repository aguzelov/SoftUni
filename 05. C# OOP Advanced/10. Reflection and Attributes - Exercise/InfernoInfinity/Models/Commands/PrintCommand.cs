using P09_InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P09_InfernoInfinity.Models.Commands
{
    public class PrintCommand : Command
    {
        public PrintCommand(string[] data) : base(data)
        {
        }

        public override void Execute(List<IWeapon> weapons)
        {
            string weaponName = this.Data[0];

            IWeapon weapon = weapons.FirstOrDefault(w => w.Name == weaponName);
            if (weapon != null)
            {
                Type writerType = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name.Contains("Writer"));

                IWriter writer = (IWriter)Activator.CreateInstance(writerType);

                writer.WriteLine(weapon.ToString());
            }
        }
    }
}