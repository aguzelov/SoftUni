using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNegativesAndReverse
{
    class RemoveNegativesAndReverse
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .Where(i => i >= 0)
                                .ToList();

            list.Reverse();

            Console.WriteLine(list.Count != 0 ? string.Join(" ", list) : "empty");
        }
    }
}
