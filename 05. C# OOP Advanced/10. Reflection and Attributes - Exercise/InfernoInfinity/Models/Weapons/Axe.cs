using P09_InfernoInfinity.Enums;

namespace P09_InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        private const int MinDmg = 5;
        private const int MaxDmg = 10;
        private const int NumberOfSockets = 4;

        public Axe(string name, RareLevel rareLevel)
            : base(name, MinDmg, MaxDmg, NumberOfSockets, rareLevel)
        {
        }
    }
}