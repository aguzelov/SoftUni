using System;
using P06_CustomEnumAttribute.Enums;

namespace P06_CustomEnumAttribute
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