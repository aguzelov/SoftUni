using DungeonsAndCodeWizards.Models;
using System;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            switch (itemName)
            {
                case "HealthPotion":
                    return new HealthPotion();

                case "ArmorRepairKit":
                    return new ArmorRepairKit();

                case "PoisonPotion":
                    return new PoisonPotion();

                default:
                    throw new ArgumentException($"Invalid item \"{ itemName }\"!");
            }
        }
    }
}