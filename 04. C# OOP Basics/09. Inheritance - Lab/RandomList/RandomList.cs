using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    public RandomList() : base()
    {
    }

    public string RandomString()
    {
        Random r = new Random();
        int index = r.Next(0, base.Count); //for ints

        string element = base[index];
        base.RemoveAt(index);
        return element;
    }
}