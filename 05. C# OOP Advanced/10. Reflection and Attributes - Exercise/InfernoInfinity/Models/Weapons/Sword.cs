using P09_InfernoInfinity.Enums;

namespace P09_InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        private const int MinDmg = 4;
        private const int MaxDmg = 6;
        private const int NumberOfSockets = 3;

        public Sword(string name, RareLevel rareLevel)
            : base(name, MinDmg, MaxDmg, NumberOfSockets, rareLevel)
        {
        }
    }
}