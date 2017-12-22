using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Five_Different_Numbers
{
    class FiveDifferentNumbers
    {
        static void print(int startNumber, int endNumber)
        {
            for (int firstNumber = startNumber; firstNumber <= endNumber; firstNumber++)
            {
                for (int secondNumber = startNumber; secondNumber <= endNumber; secondNumber++)
                {
                    for (int thirdNumber = startNumber; thirdNumber <= endNumber; thirdNumber++)
                    {
                        for (int fourthNumber = startNumber; fourthNumber <= endNumber; fourthNumber++)
                        {
                            for (int fifthNumber = startNumber; fifthNumber <= endNumber; fifthNumber++)
                            {
                                bool isTrue = (firstNumber >= startNumber && firstNumber < secondNumber && secondNumber < thirdNumber && thirdNumber < fourthNumber && fourthNumber < fifthNumber && fifthNumber <= endNumber) ? true : false;

                                if (isTrue)
                                {
                                    Console.Write(firstNumber + " ");
                                    Console.Write(secondNumber + " ");
                                    Console.Write(thirdNumber + " ");
                                    Console.Write(fourthNumber + " ");
                                    Console.WriteLine(fifthNumber);
                                }
                            }
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            if ((b - a) < 5)
            {
                Console.WriteLine("No");
                return;
            }

            print(a, b);
        }
    }
}
