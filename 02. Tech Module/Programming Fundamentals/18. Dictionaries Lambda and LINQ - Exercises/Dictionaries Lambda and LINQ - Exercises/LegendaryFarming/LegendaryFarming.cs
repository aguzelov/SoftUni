using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendaryFarming
{
    class LegendaryFarming
    {
        static Dictionary<string, long> materialsAndQuantity = new Dictionary<string, long> {
            {"motes", 0 },
            {"shards", 0 },
            {"fragments", 0 }
        };

        static void Report()
        {
            var sortedLegendaryMats = materialsAndQuantity.Take(3).OrderByDescending(v => v.Value).ThenBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (KeyValuePair<string, long> pair in sortedLegendaryMats)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            var sortedJunks = materialsAndQuantity.Skip(3).OrderBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value);
            foreach (KeyValuePair<string, long> pair in sortedJunks)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        static bool IsFarmed()
        {
            bool isFarmed = false;

            if (materialsAndQuantity["motes"] >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");
                materialsAndQuantity["motes"] -= 250;
                isFarmed = true;
                Report();
            }
            else if (materialsAndQuantity["fragments"] >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
                materialsAndQuantity["fragments"] -= 250;
                isFarmed = true;
                Report();
            }
            else if (materialsAndQuantity["shards"] >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                materialsAndQuantity["shards"] -= 250;
                isFarmed = true;
                Report();
            }

            return isFarmed;
        }

        static bool TakeInput()
        {
            string[] materials = Console.ReadLine()
                                        .Split(' ')
                                        .Where(p => !string.IsNullOrWhiteSpace(p))
                                        .ToArray();
            
            for (int i = 0; i < materials.Length - 1; i += 2)
            {
                long quantity = long.Parse(materials[i]);
                string material = materials[i + 1].ToLower();

                if (materialsAndQuantity.ContainsKey(material))
                {
                    materialsAndQuantity[material] += quantity;
                }
                else
                {
                    materialsAndQuantity.Add(material, quantity);
                }

                if (IsFarmed())
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            while (TakeInput())
            {
            }
        }
    }
}
