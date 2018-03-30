using P09_InfernoInfinity.Contracts;
using P09_InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P09_InfernoInfinity.Models.Commands
{
    public class AddCommand : Command
    {
        public AddCommand(string[] data)
            : base(data)
        {
        }

        public override void Execute(List<IWeapon> weapons)
        {
            string weaponName = this.Data[0];
            int socketIndex = int.Parse(this.Data[1]);
            string[] gemArgs = this.Data[2].Split(" ");
            string gemQualityName = gemArgs[0];
            string gemName = gemArgs[1];

            if (!Enum.TryParse(gemQualityName, out GemQualityLevel gemQualityLevel))
            {
                return;
            }

            Type gemType = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name.ToLower().Contains(gemName.ToLower()));

            IGem gem = (IGem)Activator.CreateInstance(gemType, new object[] { gemQualityLevel });

            if (gem != null)
            {
                weapons.FirstOrDefault(w => w.Name == weaponName)?.AddGem(socketIndex, gem);
            }
        }
    }
}