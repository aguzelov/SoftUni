using System;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models
{
    public abstract class Item
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
                throw new InvalidOperationException("Must be alive to perform this action!");
        }

        public override string ToString() => this.GetType().Name;
    }
}