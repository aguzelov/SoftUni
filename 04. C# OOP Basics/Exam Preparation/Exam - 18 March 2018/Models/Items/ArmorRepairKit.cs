using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models
{
    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit() 
            : base(10)
        {
        }

        public override void AffectCharacter(Character character)
        {
           base.AffectCharacter(character);
            character.Armor = character.BaseArmor;
        }
    }
}
