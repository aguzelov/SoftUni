using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] filds)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.NonPublic |
            BindingFlags.Public);

        StringBuilder sb = new StringBuilder();
        Object classInstance = Activator.CreateInstance(classType, new object[] { });
        sb.AppendLine($"Class under investigation: {className}");

        foreach (var field in classFields.Where(f => filds.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] fields = classType.GetFields(
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.Public);

        StringBuilder sb = new StringBuilder();

        foreach (var fieldInfo in fields.Where(f => !f.Name.Contains("BackingField")))
        {
            if (!fieldInfo.IsPrivate)
                sb.AppendLine($"{fieldInfo.Name} must be private!");
        }

        MethodInfo[] methods = classType.GetMethods(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);

        foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
        {
            if (!method.IsPublic)
                sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
        {
            if (!method.IsPrivate)
                sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] methods = classType.GetMethods(
            BindingFlags.NonPublic | BindingFlags.Instance);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var methodInfo in methods)
        {
            sb.AppendLine(methodInfo.Name);
        }

        return sb.ToString().Trim();
    }
}