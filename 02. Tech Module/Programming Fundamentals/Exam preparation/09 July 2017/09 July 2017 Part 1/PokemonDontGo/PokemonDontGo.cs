using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDontGo
{
    class PokemonDontGo
    {
        private static List<int> distance = new List<int>();

        private static long sum = 0;

        private static void Action(int element)
        {
            for (int i = 0; i < distance.Count; i++)
            {
                if (distance[i] <= element)
                {
                    distance[i] += element;
                }
                else
                {
                    distance[i] -= element;
                }
            }
        }

        private static int IndexLessThanZero()
        {
            int element = distance[0];
            distance[0] = distance.Last();
            return element;
        }

        private static int IndexGreaterThanCount()
        {
            int element = distance.Last();
            distance[distance.Count - 1] = distance.First();
            return element;
        }

        private static bool TakeIndexes()
        {
            if (distance.Count == 0)
            {
                return false;
            }
            int index = int.Parse(Console.ReadLine());

            int elementToRemove = 0;

            if (index < 0)
            {
                elementToRemove = IndexLessThanZero();

            }
            else if (index >= distance.Count)
            {
                elementToRemove = IndexGreaterThanCount();
            }
            else
            {
                elementToRemove = distance[index];
                distance.RemoveAt(index);
            }

            Action(elementToRemove);

            sum += elementToRemove;

            return true;
        }

        static void Main(string[] args)
        {
            distance = Console.ReadLine()
                                    .Split(' ')
                                    .Select(int.Parse)
                                    .ToList();

            while (TakeIndexes()) { }

            Console.WriteLine(sum);
        }
    }
}
