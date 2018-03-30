using P09_InfernoInfinity.Contracts;
using P09_InfernoInfinity.Enums;
using System.Linq;

namespace P09_InfernoInfinity.Models.Weapons
{
    public abstract class Weapon
    {
        private string name;
        private int minDmg;
        private int maxDmg;
        private IGem[] sockets;

        protected Weapon(string name, int minDmg, int maxDmg, int numberOfSockets, RareLevel rareLevel)
        {
            this.Name = name;

            this.MinDamage = minDmg * (int)rareLevel;
            this.MaxDamage = maxDmg * (int)rareLevel;

            this.sockets = new IGem[numberOfSockets];
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public int MinDamage
        {
            get => this.minDmg;
            private set => this.minDmg = value;
        }

        public int MaxDamage
        {
            get => this.maxDmg;
            private set => this.maxDmg = value;
        }

        public int StrengthBonus => this.sockets.Where(s => s != null).Sum(s => s.StrengthBonus);

        public int AgilityBonus => this.sockets.Where(s => s != null).Sum(s => s.AgilityBonus);

        public int VitalityBonus => this.sockets.Where(s => s != null).Sum(s => s.VitalityBonus);

        public void AddGem(int socketIndex, IGem gem)
        {
            if (CheckSocketIndex(socketIndex)) return;

            this.sockets[socketIndex] = gem;
        }

        public void Remove(int socketIndex)
        {
            if (CheckSocketIndex(socketIndex)) return;

            this.sockets[socketIndex] = null;
        }

        private bool CheckSocketIndex(int socketIndex)
        {
            if (socketIndex < 0 || socketIndex >= this.sockets.Length)
                return true;

            return false;
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.MinDamage + this.StrengthBonus * 2 + this.AgilityBonus}-{this.MaxDamage + this.StrengthBonus * 3 + this.AgilityBonus * 4} Damage, +{this.StrengthBonus} Strength, +{this.AgilityBonus} Agility, +{this.VitalityBonus} Vitality";
        }
    }
}