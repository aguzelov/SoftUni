using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SentenceTheThief
{
    class SentenceTheThief
    {
        static void Main(string[] args)
        {
            string thiefID = Console.ReadLine();
            int countOfId = int.Parse(Console.ReadLine());

            if (thiefID.Equals("int"))
            {
                List<int> ids = new List<int>();
                for (int i = 0; i < countOfId; ++i)
                {
                    if (int.TryParse(Console.ReadLine(), out int value))
                    {
                        ids.Add(value);
                    }
                }
                ids.Sort();
                double years = Math.Ceiling(ids[ids.Count - 1] / (ids[ids.Count - 1] > 0 ? (double)127 : (double)-128));
                if (years > 1)
                {
                    Console.WriteLine($"Prisoner with id {ids[ids.Count - 1]} is sentenced to {years} years");
                }
                else
                {
                    Console.WriteLine($"Prisoner with id {ids[ids.Count - 1]} is sentenced to {years} year");
                }

            }
            else if (thiefID.Equals("sbyte"))
            {
                List<sbyte> ids = new List<sbyte>();
                for (int i = 0; i < countOfId; ++i)
                {
                    if (sbyte.TryParse(Console.ReadLine(), out sbyte value))
                    {
                        ids.Add(value);
                    }
                }
                ids.Sort();
                double years = Math.Ceiling(ids[ids.Count - 1] / (ids[ids.Count - 1] > 0 ? (double)127 : (double)-128));
                if (years > 1)
                {
                    Console.WriteLine($"Prisoner with id {ids[ids.Count - 1]} is sentenced to {years} years");
                }
                else
                {
                    Console.WriteLine($"Prisoner with id {ids[ids.Count - 1]} is sentenced to {years} year");
                }
            }
            else if (thiefID.Equals("long"))
            {
                List<long> ids = new List<long>();
                for (int i = 0; i < countOfId; ++i)
                {
                    if (long.TryParse(Console.ReadLine(), out long value))
                    {
                        ids.Add(value);
                    }
                }
                ids.Sort();
                double years = Math.Ceiling(ids[ids.Count - 1] / (ids[ids.Count - 1] > 0 ? (double)127 : (double)-128));
                if (years > 1)
                {
                    Console.WriteLine($"Prisoner with id {ids[ids.Count - 1]} is sentenced to {years} years");
                }
                else
                {
                    Console.WriteLine($"Prisoner with id {ids[ids.Count - 1]} is sentenced to {years} year");
                }
            }
        }
    }
}
