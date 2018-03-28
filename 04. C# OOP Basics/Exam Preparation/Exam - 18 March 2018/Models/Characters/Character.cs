using DungeonsAndCodeWizards.Models.Bags;
using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private string name;

        private double baseHealth;
        private double health;

        private double baseArmor;
        private double armor;

        private double abilityPoints;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = this.BaseHealth;
            this.BaseArmor = armor;
            this.Armor = this.BaseArmor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
        }

        protected virtual double RestHealMultiplier => 0.2;

        public bool IsAlive { get; set; } = true;

        public Faction Faction { get; }

        public Bag Bag { get; }

        public double AbilityPoints
        {
            get { return this.abilityPoints; }
            private set { this.abilityPoints = value; }
        }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            set { this.armor = Math.Min(value, this.BaseArmor); }
        }

        public double BaseArmor
        {
            get { return this.baseArmor; }
            private set { this.baseArmor = value; }
        }

        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = Math.Min(value, this.BaseHealth);
            }
        }

        public double BaseHealth
        {
            get { return this.baseHealth; }
            private set { this.baseHealth = value; }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public void TakeDamage(double hitPoints)
        {
            CheckIsAlive(this);

            var hitpointsLeftAfterArmorDamage = Math.Max(0, hitPoints - this.Armor);
            this.Armor = Math.Max(0, this.Armor - hitPoints);
            this.Health = Math.Max(0, this.Health - hitpointsLeftAfterArmorDamage);

            if (this.Health == 0)
			{
				this.IsAlive = false;
			}
        }

        public void Rest()
        {
            CheckIsAlive(this);

            this.Health = Math.Min(this.Health + this.BaseHealth * this.RestHealMultiplier, this.BaseHealth);
        }

        public void UseItem(Item item)
        {
            UseItemOn(item, this);
        }

        public void UseItemOn(Item item, Character character)
        {
            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.Bag.AddItem(item);
        }

        protected void CheckIsAlive(Character character)
        {
            if (!character.IsAlive)
                throw new InvalidOperationException("Must be alive to perform this action!");
        }

        public override string ToString()
        {
            string status = this.IsAlive ? "Alive" : "Dead";

            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }
    }
}