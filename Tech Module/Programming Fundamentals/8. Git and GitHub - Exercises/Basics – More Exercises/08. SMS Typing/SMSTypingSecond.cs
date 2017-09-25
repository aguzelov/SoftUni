using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.SMS_Typing
{
    class SMSTypingSecond
    {
        static string letters = "abcdefghijklmnopqrstuvwxyz";

        static void Main(string[] args)
        {
            int numberOfLetter = int.Parse(Console.ReadLine());
            string button;

            string text = "";

            int numberOfDigits;
            int mainNumber;
            int offset;
            int letterIndex;

            while (numberOfLetter != 0)
            {
                button = Console.ReadLine();
                if(button == "0")
                {
                    text += " ";
                    numberOfLetter--;
                    continue;
                }
                numberOfDigits = button.Length;
                mainNumber = int.Parse(button[0].ToString());
                offset = (mainNumber - 2) * 3;
                if (mainNumber == 8 || mainNumber == 9)
                {
                    offset += 1;
                }

                letterIndex = (offset + numberOfDigits - 1);
                text += letters[letterIndex];

                numberOfLetter--;
            }
            Console.WriteLine(text);
        }
    }
}
