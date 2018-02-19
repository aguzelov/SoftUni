using System;

class StartUp
{
    static void Main(string[] args)
    {
        string mainPersonInput = Console.ReadLine();
        FamilyTreeBuilder familyTreeBuilder = new FamilyTreeBuilder(mainPersonInput);

        
        while (ParseInput(familyTreeBuilder))
        {
        }

        string familyTree = familyTreeBuilder.Build();
        Console.WriteLine(familyTree);
    }

    private static bool ParseInput(FamilyTreeBuilder familyTreeBuilder)
    {
        string input = Console.ReadLine();
        if (input == "End") return false;

        string[] tokens = input.Split(" - ");
        if (tokens.Length > 1)
        {
            ParentChild(familyTreeBuilder, tokens);
        }
        else
        {
            FullInfo(familyTreeBuilder, tokens);
        }

        return true;
    }

    private static void FullInfo(FamilyTreeBuilder familyTreeBuilder, string[] tokens)
    {
        tokens = tokens[0].Split();
        string name = $"{tokens[0]} {tokens[1]}";
        string birthday = tokens[2];

        familyTreeBuilder.SetFullInfo(name, birthday);
    }

    private static void ParentChild(FamilyTreeBuilder familyTreeBuilder, string[] tokens)
    {
        string parentInput = tokens[0];
        string childInput = tokens[1];
        familyTreeBuilder.SetParentChildRelation(parentInput, childInput);
    }
}
