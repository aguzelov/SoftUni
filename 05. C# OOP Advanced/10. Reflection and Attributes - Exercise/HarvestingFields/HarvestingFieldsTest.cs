using System.Linq;
using System.Reflection;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            while (true)
            {
                string accessModifier = Console.ReadLine();
                if (accessModifier == "HARVEST") break;

                var harvestingType = typeof(HarvestingFields);
                var fieldInfos = harvestingType.GetFields(
                    BindingFlags.Instance |
                    BindingFlags.NonPublic |
                    BindingFlags.Public |
                    BindingFlags.Static);

                fieldInfos = FieldInfos(fieldInfos, accessModifier);

                foreach (var fieldInfo in fieldInfos)
                {
                    string fieldAccessModifier = fieldInfo.Attributes.ToString().ToLower() == "family"
                        ? "protected"
                        : fieldInfo.Attributes.ToString().ToLower();

                    Console.WriteLine($"{fieldAccessModifier} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
            }
        }

        private static FieldInfo[] FieldInfos(FieldInfo[] fieldInfos, string accessModifier)
        {
            switch (accessModifier)
            {
                case "public":
                    fieldInfos = fieldInfos.Where(f => f.IsPublic).ToArray();
                    break;

                case "private":
                    fieldInfos = fieldInfos.Where(f => f.IsPrivate).ToArray();
                    break;

                case "protected":
                    fieldInfos = fieldInfos.Where(f => f.IsFamily).ToArray();
                    break;
            }

            return fieldInfos;
        }
    }
}