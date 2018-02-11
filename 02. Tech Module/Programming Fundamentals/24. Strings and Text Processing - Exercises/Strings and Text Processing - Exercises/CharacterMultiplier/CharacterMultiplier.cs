using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CharacterMultiplier
{
    class CharacterMultiplier
    {
        static BigInteger CharSum(string[] input)
        {
            int[] firstArraySum = input[0].Select(c => (int)c).ToArray();
            int[] secondArraySum = input[1].Select(c => (int)c).ToArray();

            int minArrayLength = Math.Min(firstArraySum.Length, secondArraySum.Length);
            int maxArrayLength = Math.Max(firstArraySum.Length, secondArraySum.Length);
            BigInteger sum = new BigInteger(0);

            for(int i = 0; i < minArrayLength; i++)
            {
                sum += firstArraySum[i] * secondArraySum[i];
            }
            
            if(firstArraySum.Length > secondArraySum.Length)
            {
                int s = firstArraySum.Skip(minArrayLength).Take(maxArrayLength - minArrayLength).Sum();
                
                sum += s;
            }
            else if (secondArraySum.Length > firstArraySum.Length)
            {
                int s = secondArraySum.Skip(minArrayLength).Take(maxArrayLength - minArrayLength).Sum();
                
                sum += s;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split(' ')
                                    .Where(p => !string.IsNullOrWhiteSpace(p))
                                    .ToArray();

            Console.WriteLine(CharSum(input));
        }
    }
}
