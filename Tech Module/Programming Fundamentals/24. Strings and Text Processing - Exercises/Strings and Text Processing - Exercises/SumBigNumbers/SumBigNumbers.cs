using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumBigNumbers
{
    class SumBigNumbers
    {
        static void TakeString(out string number)
        {
            number = Console.ReadLine().Trim();
        }

        static void Main(string[] args)
        {
            TakeString(out string firstNumber);
            TakeString(out string secondNumber);

            bool carry = false;

            string result = String.Empty;

            string stringWithLargeLength = (firstNumber.Length >= secondNumber.Length ? firstNumber : secondNumber);

            foreach (char c in stringWithLargeLength)
            {
                int augend;
                if (firstNumber.Length != 0)
                {
                    augend = Convert.ToInt32(firstNumber.Last().ToString());
                    firstNumber = firstNumber.Remove(firstNumber.Length - 1, 1);
                }
                else
                {
                    augend = 0;
                }

                int addend;
                if (secondNumber.Length != 0)
                {
                    addend = Convert.ToInt32(secondNumber.Last().ToString());
                    secondNumber = secondNumber.Remove(secondNumber.Length - 1, 1);
                }
                else
                {
                    addend = 0;
                }



                int sum = augend + addend;
                sum += (carry ? 1 : 0);
                carry = false;

                if (sum > 9)
                {
                    carry = true;
                    sum -= 10;
                }

                result = sum.ToString() + result;
            }

            if (carry)
            {
                result = "1" + result;
            }
            Console.WriteLine(result.TrimStart(new char[] { '0' }));
        }
    }
}
