using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private IList<T> list;
    private int current;

    public ListyIterator(IList<T> list)
    {
        this.list = list;
        this.Reset();
    }

    public bool Move()
    {
        bool hasMove = ++this.current < this.list.Count;

        if (!hasMove) this.current--;

        return hasMove;
    }

    public bool HasNext()
    {
        return this.current < this.list.Count - 1;
    }

    public T Print()
    {
        if (this.list.Count == 0)
            throw new InvalidOperationException("Invalid Operation!");

        return this.list[this.current];
    }

    private void Reset()
    {
        this.current = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.list.Count; i++)
        {
            yield return this.list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}