using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static decimal sum = 0;

        static void TakeStringArray(out string[] array)
        {
            array = Console.ReadLine().Split(' ').Where(p => !string.IsNullOrWhiteSpace(p)).Select(p => p.Trim()).ToArray();
        }

        static void Seperate(out string[] array, string line)
        {
            array = new string[3];

            array[0] = line.First().ToString();

            array[1] = ExtractNumber(line).ToString();

            array[2] = line.Last().ToString();
        }

        static string ExtractNumber(string line)
        {
            string number = new string(line.Where(p => (p >= '0' && p <= '9')).ToArray());

            return number;
        }

        static void Calculate(string[] array)
        {
            decimal number = LeftLetterOperation(array[0], array[1]);
            number = RightLetterOperation(array[2], number);
            sum += number;
        }

        static decimal LeftLetterOperation(string letter, string number)
        {
            decimal position = ((int)char.ToUpper(letter[0])) - 64;

            decimal newNumber = 0;

            if (char.IsUpper(letter[0]))
            {
                // divide the number by the letter`s position in the alphabet
                newNumber = decimal.Parse(number) / position;
            }
            else
            {
                // multiply the number by the letter`s position in the alphabet
                newNumber = decimal.Parse(number) * position;
            }
            return newNumber;
        }

        static decimal RightLetterOperation(string letter, decimal number)
        {
            decimal position = ((int)char.ToUpper(letter[0])) - 64;

            decimal newNumber = 0;

            if (char.IsUpper(letter[0]))
            {
                // divide the number by the letter`s position in the alphabet
                newNumber = number - position;
            }
            else
            {
                // multiply the number by the letter`s position in the alphabet
                newNumber = number + position;
            }
            return newNumber;
        }


        static void Main(string[] args)
        {
            TakeStringArray(out string[] input);


            foreach (string line in input)
            {
                Seperate(out string[] array, line);

                Calculate(array);
            }

            Console.WriteLine(string.Format("{0:0.00}", sum));
        }
    }
}
