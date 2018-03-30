using P09_InfernoInfinity.Enums;

namespace P09_InfernoInfinity.Models.Gems
{
    public class Emerald : Gem
    {
        private const int baseStrength = 1;
        private const int baseAgility = 4;
        private const int baseVitality = 9;

        public Emerald(GemQualityLevel gemQualityLevel)
            : base(gemQualityLevel, baseStrength, baseAgility, baseVitality)
        {
        }
    }
}