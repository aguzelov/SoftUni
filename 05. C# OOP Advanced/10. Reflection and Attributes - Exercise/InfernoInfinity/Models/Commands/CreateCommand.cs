﻿using P09_InfernoInfinity.Contracts;
using P09_InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P09_InfernoInfinity.Models.Commands
{
    public class CreateCommand : Command
    {
        public CreateCommand(string[] data) : base(data)
        {
        }

        public override void Execute(List<IWeapon> weapons)
        {
            string[] weaponTypeArgs = this.Data[0].Split(" ");

            string rareTypeName = weaponTypeArgs[0];
            string weaponTypeName = weaponTypeArgs[1];
            string weaponName = this.Data[1];

            if (!Enum.TryParse(rareTypeName, out RareLevel rareLevel))
            {
                return;
            }

            object[] parameter =
            {
                weaponName, rareLevel
            };

            Type weaponType = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name.ToLower().Contains(weaponTypeName.ToLower()));

            IWeapon weapon = (IWeapon)Activator.CreateInstance(weaponType, parameter);

            if (weapon != null)
            {
                weapons.Add(weapon);
            }
        }
    }
}