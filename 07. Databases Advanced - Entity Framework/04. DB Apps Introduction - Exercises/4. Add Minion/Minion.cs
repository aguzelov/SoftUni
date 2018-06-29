using System;

public class Minion
{
    private string name;
    private int age;
    private string town;
    private string villianName;

    public Minion()
    {
        InitMinion();
    }

    public string Name
    {
        get { return this.name; }
    }

    public int Age
    {
        get { return this.age; }
    }

    public string Town
    {
        get { return this.town; }
    }

    public string Villian
    {
        get { return this.villianName; }
    }

    private void InitMinion()
    {
        string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        this.name = input[1];
        this.age = int.Parse(input[2]);
        this.town = input[3];

        input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        this.villianName = input[1];
    }
}