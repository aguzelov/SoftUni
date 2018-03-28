using DungeonsAndCodeWizards.Models.Bags;
using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction)
            : base(name, 100, 50, 40, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            CheckIsAlive(this);

            if (this == character)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction.ToString()} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}