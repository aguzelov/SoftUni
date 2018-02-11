using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnonymousCache
{
    class AnonymousCache
    {
        private static Dictionary<string, Dictionary<string, long>> set = new Dictionary<string, Dictionary<string, long>>();
        private static Dictionary<string, Dictionary<string, long>> cache = new Dictionary<string, Dictionary<string, long>>();

        static void Main(string[] args)
        {
            while (TakeInput()) { }
        }

        private static bool TakeInput()
        {
            string input = Console.ReadLine();
            if (input == "thetinggoesskrra")
            {
                Print();
                return false;
            }

            string[] array = input.Split(new char[] { ' ', '-', '>', '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (array.Length == 1)
            {
                //dataSet only
                string dataSet = array[0];
                Add(dataSet);
            }
            else if (array.Length == 3)
            {
                string dataKey = array[0];
                long dataSize = long.Parse(array[1]);
                string dataSet = array[2];
                Add(dataKey, dataSize, dataSet);
            }


            return true;
        }

        private static void Print()
        {
            if (set.Count == 0)
            {
                return;
            }

            foreach (var pair in set.OrderByDescending(x => x.Value.Values.Sum()).Take(1))
            {
                Console.WriteLine($"Data Set: {pair.Key}, Total Size: {pair.Value.Values.Sum()}");

                foreach (var subPair in pair.Value)
                {
                    Console.WriteLine($"$.{subPair.Key}");
                }
            }
        }

        private static void Add(string dataKey, long dataSize, string dataSet)
        {
            if (set.ContainsKey(dataSet))
            {
                set[dataSet].Add(dataKey, dataSize);
            }
            else
            {
                if (cache.ContainsKey(dataSet))
                {
                    cache[dataSet].Add(dataKey, dataSize);
                }
                else
                {
                    cache.Add(dataSet, new Dictionary<string, long> { { dataKey, dataSize } });
                }
            }
        }

        private static void Add(string dataSet)
        {
            if (!set.ContainsKey(dataSet))
            {
                set.Add(dataSet, new Dictionary<string, long>());
                if (cache.ContainsKey(dataSet))
                {

                    foreach (var pair in cache[dataSet])
                    {
                        set[dataSet].Add(pair.Key, pair.Value);
                    }
                }
            }
        }
    }
}
