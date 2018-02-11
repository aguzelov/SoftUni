using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyBigNumber
{
    class MultiplyBigNumber
    {
        static void TakeString(out int[] number)
        {
            number = Console.ReadLine().Select(p => int.Parse(p.ToString())).ToArray();
        }

        static void Main(string[] args)
        {
            TakeString(out int[] firstNumber);
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }
            int carry = 0;

            string result = String.Empty;

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                int t = (firstNumber[i] * number) + carry;
                carry = t / 10;
                result = (t % 10).ToString() + result;

            }
            if (carry > 0)
            {
                result = carry.ToString() + result;
            }

            Console.WriteLine(string.Join("", result).TrimStart(new char[] { '0' }));
        }
    }
}
