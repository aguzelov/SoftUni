using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Different_Integers_Size
{
    class DifferentIntegersSize
    {
        static Dictionary<string, string> types = new Dictionary<string, string>
        {
            {"System.SByte", "sbyte" },
            {"System.Byte", "byte" },
            {"System.Int16", "short" },
            {"System.UInt16", "ushort" },
            {"System.Int32", "int" },
            {"System.UInt32", "uint" },
            {"System.Int64", "long" }
        };
        public static void TryConvertTo<T>(string input)
        {
            Object result = null;
            try
            {
                result = Convert.ChangeType(input, typeof(T));
                Console.WriteLine("* " + types[typeof(T).ToString()]);
            }
            catch
            {
            }
        }
        public static bool IsFitInLong(string input)
        {
            try
            {
                long result = Convert.ToInt64(input);
            }
            catch (OverflowException)
            {
                return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            if (input != null && IsFitInLong(input))
            {
                Console.WriteLine($"{input} can fit in:");
                TryConvertTo<sbyte>(input);
                TryConvertTo<byte>(input);
                TryConvertTo<short>(input);
                TryConvertTo<ushort>(input);
                TryConvertTo<int>(input);
                TryConvertTo<uint>(input);
                TryConvertTo<long>(input);
            }
            else
            {
                Console.WriteLine($"{input} can't fit in any type");
            }
        }
    }
}
