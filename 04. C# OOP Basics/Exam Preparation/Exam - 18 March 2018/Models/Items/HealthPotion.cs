using DungeonsAndCodeWizards.Models.Characters;
using System;

namespace DungeonsAndCodeWizards.Models
{
    public class HealthPotion : Item
    {
        private readonly int healAmount = 20;

        public HealthPotion() 
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += this.healAmount;
        }
    }
}