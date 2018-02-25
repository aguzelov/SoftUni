using System;

internal class StartUp
{
    private static void Main()
    {
        string[] elements = Console.ReadLine().Split();

        AddCollection addCollection = new AddCollection();
        AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        MyList myList = new MyList();

        foreach (string element in elements)
        {
            addCollection.Add(element);
            addRemoveCollection.Add(element);
            myList.Add(element);
        }
        Console.WriteLine(addCollection.AddIndexes);
        Console.WriteLine(addRemoveCollection.AddIndexes);
        Console.WriteLine(myList.AddIndexes);

        int elementToRemove = int.Parse(Console.ReadLine());
        for (int i = 1; i <= elementToRemove; i++)
        {
            addRemoveCollection.Remove();
            myList.Remove();
        }

        Console.WriteLine(addRemoveCollection.RemovedElements);
        Console.WriteLine(myList.RemovedElements);
    }
}