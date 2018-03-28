using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models
{
    public class PoisonPotion : Item
    {
        private readonly int poisonDmg = 20;

        public PoisonPotion() 
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
          
            character.Health = Math.Max(0, character.Health - this.poisonDmg);

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
