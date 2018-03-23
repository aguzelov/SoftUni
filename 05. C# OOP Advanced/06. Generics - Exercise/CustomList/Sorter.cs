using System;
using System.Linq;

public class Sorter
{
    public void Sort<T>(ICustomList<T> list)
    where T : IComparable<T>
    {
        list.OrderByDescending(e => e);
    }
}