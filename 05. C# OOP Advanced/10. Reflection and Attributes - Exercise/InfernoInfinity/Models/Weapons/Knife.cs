using P09_InfernoInfinity.Enums;

namespace P09_InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        private const int MinDmg = 3;
        private const int MaxDmg = 4;
        private const int NumberOfSockets = 2;

        public Knife(string name, RareLevel rareLevel)
            : base(name, MinDmg, MaxDmg, NumberOfSockets, rareLevel)
        {
        }
    }
}