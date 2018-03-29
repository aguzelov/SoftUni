using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type blackBoxType = typeof(BlackBoxInteger);

            ConstructorInfo constructor =
                blackBoxType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];

            BlackBoxInteger blackBox = (BlackBoxInteger)constructor.Invoke(new object[] { 0 });

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split("_");
                string methodName = tokens[0];
                int methodArg = int.Parse(tokens[1]);

                InvokeMethodAndPrintValue(blackBoxType, blackBox, methodName, methodArg);
            }
        }

        private static void InvokeMethodAndPrintValue(Type blackBoxType, BlackBoxInteger blackBox, string methodName, int methodArg)
        {
            MethodInfo method = blackBoxType.GetMethod(methodName,
                BindingFlags.Instance | BindingFlags.NonPublic);

            method.Invoke(blackBox, new object[] { methodArg });

            FieldInfo innerValue = blackBoxType.GetField("innerValue",
                BindingFlags.Instance |
                BindingFlags.NonPublic);

            Console.WriteLine(innerValue.GetValue(blackBox));
        }
    }
}