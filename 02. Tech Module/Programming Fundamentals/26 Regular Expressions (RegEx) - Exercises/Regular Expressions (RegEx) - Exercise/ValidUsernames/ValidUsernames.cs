using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(^|(?<=\(|\)|\\|\/|, | ))(?<name>[a-zA-Z][a-z-A-Z0-9_]{2,25}\b)";

            string[] names = Regex.Matches(input, pattern)
                                  .Cast<Match>()
                                  .Select(a => a.Groups["name"].Value)
                                  .ToArray();

            List<Pair> pairs = new List<Pair>();

            for (int i = 0; i < names.Length; i++)
            {
                if (i + 1 < names.Length)
                {
                    pairs.Add(new Pair(names[i], names[i + 1]));

                }
                else
                {
                    pairs.Add(new Pair(names[i]));
                }
            }


            var maxLength = pairs.Max(x => x.PairLength);
            Pair biggestSum = pairs.Find(x => x.PairLength == maxLength);

            biggestSum.PrintPair();
        }
    }

    class Pair
    {
        private string first;
        private string second;
        private bool isAllSet = false;
        private int pairLength;

        public Pair(string first)
        {
            this.first = first;
            this.pairLength = first.Length;
        }

        public Pair(string first, string second)
        {
            this.first = first;
            this.second = second;
            this.pairLength = first.Length;
            this.pairLength += second.Length;
            this.isAllSet = true;
        }

        public string First { get => first; set => first = value; }
        public string Second { get => second; set => second = value; }
        public bool IsAllSet { get => isAllSet; }
        public int PairLength { get => pairLength; }

        public void Add(string name, string option)
        {
            if (option == "first" && IsAllSet == false)
            {
                this.first = name;
                this.pairLength = First.Length;

            }
            else if (option == "second" && IsAllSet == false)
            {
                this.second = name;
                this.pairLength += Second.Length;
                this.isAllSet = true;
            }
        }

        public void PrintPair()
        {
            Console.WriteLine($"{this.first}{Environment.NewLine}{this.second}");
        }
    }
}

