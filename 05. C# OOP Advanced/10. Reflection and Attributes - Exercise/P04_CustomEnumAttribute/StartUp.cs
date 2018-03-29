using System;
using P04_CustomEnumAttribute.Enums;

namespace P04_CustomEnumAttribute
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            var targetEnum = Console.ReadLine();

            var enumType = targetEnum == "Rank"
                ? typeof(Rank)
                : typeof(Suit);

            var attributes = enumType.GetCustomAttributes(false);
            Console.WriteLine(string.Join(Environment.NewLine, attributes));
        }
    }
}