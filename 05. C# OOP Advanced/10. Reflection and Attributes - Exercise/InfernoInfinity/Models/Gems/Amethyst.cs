using P09_InfernoInfinity.Enums;

namespace P09_InfernoInfinity.Models.Gems
{
    public class Amethyst : Gem
    {
        private const int baseStrength = 2;
        private const int baseAgility = 8;
        private const int baseVitality = 4;

        public Amethyst(GemQualityLevel gemQualityLevel)
            : base(gemQualityLevel, baseStrength, baseAgility, baseVitality)
        {
        }
    }
}