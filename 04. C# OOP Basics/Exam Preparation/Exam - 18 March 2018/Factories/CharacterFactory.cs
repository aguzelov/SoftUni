using DungeonsAndCodeWizards.Models;
using DungeonsAndCodeWizards.Models.Characters;
using System;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            switch (characterType)
            {
                case "Warrior":
                    return new Warrior(name, parsedFaction);

                case "Cleric":
                    return new Cleric(name, parsedFaction);

                default:
                    throw new ArgumentException($"Invalid character type \"{ characterType }\"!");
            }
        }
    }
}