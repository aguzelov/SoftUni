using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombNumbers
{
    class BombNumbers
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                                .Split(' ')
                                .Where(p => !string.IsNullOrWhiteSpace(p))
                                .ToList();

            int[] bombNumbersAndPower = Console.ReadLine()
                                                .Split(' ')
                                                .Select(int.Parse)
                                                .ToArray();

            int bombNumber = bombNumbersAndPower[0];
            int power = bombNumbersAndPower[1];

            bool isFound = false;

            do
            {
                isFound = false;
                for (int i = 0; i < list.Count; i++)
                {
                    decimal num = decimal.Parse(list[i]);
                    if (num == bombNumber)
                    {
                        isFound = true;
                        int leftPart = i + 1 > power ? power : i;
                        int rightPart = (i + 1 + power) > list.Count ? (list.Count - i- 1) : power;

                        list.RemoveRange(i-leftPart, leftPart + 1 + rightPart);
                    }
                }
            } while (isFound);

            decimal sum = 0;
            foreach(string word in list)
            {
                sum += decimal.Parse(word);
            }
            Console.WriteLine(sum);
        }
    }
}
