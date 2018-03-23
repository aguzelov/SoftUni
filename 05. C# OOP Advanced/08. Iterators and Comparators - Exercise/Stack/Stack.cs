using System;
using System.Collections;
using System.Collections.Generic;

public class Stack<T> : IEnumerable<T>
{
    private IList<T> _data;

    public Stack()
    {
        this._data = new List<T>();
    }

    public void Push(params T[] elements)
    {
        foreach (var element in elements)
        {
            this._data.Add(element);
        }
    }

    public void Pop()
    {
        int lastIndex = this._data.Count - 1;
        if (lastIndex < 0)
        {
            throw new InvalidOperationException("No elements");
        }

        this._data.RemoveAt(lastIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        int lastIndex = this._data.Count - 1;
        for (int index = lastIndex; index >= 0; index--)
        {
            yield return this._data[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}