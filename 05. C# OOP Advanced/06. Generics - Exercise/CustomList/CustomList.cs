using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> : ICustomList<T>
where T : IComparable<T>
{
    private IList<T> _data;

    public CustomList()
    {
        this._data = new List<T>();
    }

    public void Add(T element)
    {
        this._data.Add(element);
    }

    public T Remove(int index)
    {
        if (IndexOutOfRange(index))
            throw new IndexOutOfRangeException();

        T element = this._data[index];

        this._data.RemoveAt(index);

        return element;
    }

    public bool Contains(T element)
    {
        bool result = this._data.Contains(element);

        return result;
    }

    public void Swap(int index1, int index2)
    {
        if (IndexOutOfRange(index1) &&
           IndexOutOfRange(index2))
            throw new IndexOutOfRangeException();

        T tempElement = this._data[index1];
        this._data[index1] = this._data[index2];
        this._data[index2] = tempElement;
    }

    public int CountGreaterThan(T element)
    {
        int counter = 0;

        for (int i = 0; i < this._data.Count; i++)
        {
            if (this.Compare(this._data[i], element) > 0) counter++;
        }

        return counter;
    }

    public T Max()
    {
        T max = this._data[0];

        for (int i = 0; i < this._data.Count; i++)
        {
            if (this.Compare(this._data[i], max) > 0) max = this._data[i];
        }

        return max;
    }

    public T Min()
    {
        T min = this._data[0];

        for (int i = 0; i < this._data.Count; i++)
        {
            if (this.Compare(this._data[i], min) < 0) min = this._data[i];
        }

        return min;
    }

    public void Sort()
    {
        this._data = this._data.OrderBy(e => e).ToList();
    }

    private int Compare(T first, T second)
    {
        return first.CompareTo(second);
    }

    private bool IndexOutOfRange(int index)
    {
        return index < 0 || index >= this._data.Count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this._data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}