using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AMinerTask
{
    class AMinerTask
    {
        static Dictionary<string, string> resources = new Dictionary<string, string> { };

        static void AddResources(string resource, string quantity)
        {
            if (resources.ContainsKey(resource))
            {
                BigInteger currQuantity = BigInteger.Parse(resources[resource]);

                BigInteger newQuantity = currQuantity + (BigInteger.Parse(quantity));

                resources[resource] = newQuantity.ToString();
            }
            else
            {
                resources.Add(resource, quantity);
            }
        }

        static void PrintResources()
        {
            foreach (KeyValuePair<string, string> pair in resources)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }

        static void TakeInput(out string resourse, out string quantity)
        {
            resourse = Console.ReadLine();
            quantity = "";
            if (resourse == "stop")
            {
                PrintResources();
            }
            else
            {
                quantity = Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            TakeInput(out string resourse, out string quantity);
            while (resourse != "stop")
            {
                AddResources(resourse, quantity);
                TakeInput(out resourse, out quantity);
            }
        }
    }
}
