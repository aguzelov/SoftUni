using P09_InfernoInfinity.Enums;

namespace P09_InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        private const int baseStrength = 7;
        private const int baseAgility = 2;
        private const int baseVitality = 5;

        public Ruby(GemQualityLevel gemQualityLevel)
            : base(gemQualityLevel, baseStrength, baseAgility, baseVitality)
        {
        }
    }
}